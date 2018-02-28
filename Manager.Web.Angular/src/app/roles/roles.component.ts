import { Component, OnInit } from '@angular/core';
import { MatTableModule } from "@angular/material/table";
import { RoleService } from './role.service';
import { Role } from './role';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {
  //rolesDataSource = new MatTableDataSource<any>();
  displayedColumns = ['id', 'name'];
  roles: Role[];

  constructor(private roleService: RoleService) { }

  ngOnInit() {
    this.getRoles()
  }

  getRoles(): void {
    this.roleService.getRoles()
      .subscribe(roles => this.roles = roles);
  }
}
