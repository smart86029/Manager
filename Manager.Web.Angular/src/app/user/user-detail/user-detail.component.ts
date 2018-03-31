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
  saveMode = SaveMode.Create;
  user = new User();

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.userService.getUser(id)
        .subscribe(user => {this.user = user;console.log(this.user);});
    } else {
      this.user = new User();
    }
  }

  save() {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back() {
    this.location.back();
  }

  private create() {
    this.userService.createUser(this.user)
      .subscribe(user => this.location.back());
  }

  private update() {
    this.userService.updateUser(this.user)
      .subscribe(user => this.location.back());
  }
}
