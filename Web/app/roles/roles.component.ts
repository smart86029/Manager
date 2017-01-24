import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from './role';
import { RoleService } from './role.service';

declare var $: any;

@Component({
  moduleId: module.id,
  selector: 'my-roles',
  templateUrl: 'roles.component.html',
  styleUrls: ['roles.component.css']
})
export class RolesComponent implements OnInit {
  roles: Role[];
  newRole: Role;
  selectedRole: Role;
  errorMessage: string;

  constructor(
    private router: Router,
    private roleService: RoleService) { }

  ngOnInit(): void {
    this.getRoles();
    this.newRole = new Role();
    $('.modal').modal();
  }

  getRoles(): void {
    this.roleService.getRoles()
      .subscribe(
        roles => this.roles = roles,
        error => this.errorMessage = <any>error);
  }

  addRole() {
    console.log("2");
    this.roleService.addRole(this.newRole)
      .subscribe(
        role => this.roles.push(role),
        error => this.errorMessage = <any>error);
  }

  onSelect(role: Role): void {
    this.selectedRole = role;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedRole.RoleId]);
  }
}