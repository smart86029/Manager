import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { Role } from './role';
import { RoleService } from './role.service';
@Component({
  moduleId: module.id,
  selector: 'my-role-detail',
  templateUrl: 'role-detail.component.html',
  styleUrls: ['role-detail.component.css']
})
export class RoleDetailComponent implements OnInit {
  role: Role;

  constructor(
    private roleService: RoleService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    //this.route.params
    //  .switchMap((params: Params) => this.roleService.getRole(+params['id']))
    //  .subscribe(role => this.role = role);
  }

  goBack(): void {
    this.location.back();
  }
}