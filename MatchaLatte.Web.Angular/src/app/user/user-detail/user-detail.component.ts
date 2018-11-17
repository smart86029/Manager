import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SaveMode } from 'src/app/shared/save-mode/save-mode.enum';

import { User } from '../user';
import { UserService } from '../user.service';
import { Guid } from 'src/app/shared/guid';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {
  isLoading: boolean;
  saveMode = SaveMode.Create;
  user = new User();

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.userService.getUser(id)
        .subscribe(user => this.user = user, () => { }, () => this.isLoading = false);
    } else {
      this.userService.getNewUser()
        .subscribe(user => this.user = user, () => { }, () => this.isLoading = false);
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.userService.createUser(this.user)
      .subscribe(user => this.location.back());
  }

  private update(): void {
    this.userService.updateUser(this.user)
      .subscribe(user => this.location.back());
  }
}
