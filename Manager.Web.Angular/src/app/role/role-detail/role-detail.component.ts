import { Location } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.css']
})
export class RoleDetailComponent implements OnInit {
  role: Role = new Role();

  constructor(private roleService: RoleService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.roleService.getRole(id)
        .subscribe(role => this.role = role);
    } else {
      this.role = new Role();
    }
  }

  create() {
    this.roleService.createRole(this.role)
      .subscribe(role => this.location.back());
  }

  update() {
    this.roleService.updateRole(this.role)
      .subscribe(role => this.location.back());
  }
}
