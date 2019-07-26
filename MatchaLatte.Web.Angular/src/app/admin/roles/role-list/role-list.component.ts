import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/core/pagination-result';
import { RoleService } from 'src/app/core/role/role.service';
import { Role } from 'src/app/core/user/role';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  isLoading = false;
  roles = new PaginationResult<Role>();
  dataSource = new MatTableDataSource<Role>();
  displayedColumns = ['rowId', 'name', 'isEnabled', 'action'];

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
    this.loadRoles(this.roles.pageIndex, this.roles.pageSize);
  }

  loadRoles(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.roleService
      .getRoles(pageIndex, pageSize)
      .subscribe({
        next: roles => {
          this.roles = roles;
          this.dataSource.data = roles.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
