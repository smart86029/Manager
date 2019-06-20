import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/shared/pagination-result';

import { Permission } from '../permission';
import { PermissionService } from '../permission.service';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styleUrls: ['./permission-list.component.scss']
})
export class PermissionListComponent implements OnInit {
  isLoading: boolean;
  permissions = new PaginationResult<Permission>();
  dataSource = new MatTableDataSource<Permission>();
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];

  constructor(private permissionService: PermissionService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.loadPermissions(this.permissions.pageIndex, this.permissions.pageSize);
  }

  loadPermissions(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.permissionService
      .getPermissions(pageIndex, pageSize)
      .subscribe({
        next: result => {
          this.permissions = result;
          this.dataSource.data = result.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
