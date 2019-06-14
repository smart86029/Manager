import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/shared/pagination-result';

import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  isLoading = false;
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<Role>();
  roles = new PaginationResult<Role>();

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
    this.getRoles(this.roles.pageIndex, this.roles.pageSize);
  }

  private getRoles(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.roleService
      .getRoles(pageIndex, pageSize)
      .subscribe({
        next: result => {
          this.dataSource.data = result.items;
          this.roles = result;
        },
        complete: () => this.isLoading = false
      });
  }
}
