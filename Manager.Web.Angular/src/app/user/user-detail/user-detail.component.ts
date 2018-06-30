import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { User } from '../user';
import { UserService } from '../user.service';
import { Role } from '../../role/role';
import { RoleService } from '../../role/role.service';

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
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.isLoading = true;
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
