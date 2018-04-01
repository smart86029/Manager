import { Component, OnInit } from '@angular/core';

import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  roles: Role[];

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
    this.getRoles();
  }

  private getRoles(): void {
    this.roleService.getRoles()
      .subscribe(roles => this.roles = roles);
  }
}
