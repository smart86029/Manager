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
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<Permission>();
  permissions = new PaginationResult<Permission>();

  constructor(private permissionService: PermissionService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.getPermissions(this.permissions.pageIndex, this.permissions.pageSize);
  }

  private getPermissions(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.permissionService
      .getPermissions(pageIndex, pageSize)
      .subscribe({
        next: result => {
          this.dataSource.data = result.items;
          this.permissions = result;
        },
        complete: () => this.isLoading = false
      });
  }
}
