﻿import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Role } from './role';
import { RoleService } from './role.service';

@Component({
  moduleId: module.id,
  selector: 'my-roles',
  templateUrl: 'roles.component.html',
  styleUrls: ['roles.component.css']
})
export class RolesComponent implements OnInit {
  roles: Role[];
  selectedRole: Role;

  constructor(
    private router: Router,
    private roleService: RoleService) { }

  getRoles(): void {
    this.roleService.getRoles().then(roles => this.roles = roles);
  }

  ngOnInit(): void {
    this.getRoles();
  }

  onSelect(role: Role): void {
    this.selectedRole = role;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedRole.id]);
  }
}