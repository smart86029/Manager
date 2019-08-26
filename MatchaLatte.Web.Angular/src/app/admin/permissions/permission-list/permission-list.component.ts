import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/core/pagination-result';
import { Permission } from 'src/app/core/permission/permission';
import { PermissionService } from 'src/app/core/permission/permission.service';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styleUrls: ['./permission-list.component.scss']
})
export class PermissionListComponent implements OnInit {
  isLoading: boolean;
  permissions = new PaginationResult<Permission>();
  dataSource = new MatTableDataSource<Permission>();
  displayedColumns = ['rowId', 'code', 'name', 'isEnabled', 'action'];

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
    this.loadPermissions(this.permissions.pageIndex, this.permissions.pageSize);
  }

  loadPermissions(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.permissionService
      .getPermissions(pageIndex, pageSize)
      .subscribe({
        next: permissions => {
          this.permissions = permissions;
          this.dataSource.data = permissions.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
