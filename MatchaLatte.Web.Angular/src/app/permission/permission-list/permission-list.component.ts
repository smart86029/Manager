import { Component, ComponentFactoryResolver, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
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

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private permissionService: PermissionService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.getPermissions(this.permissions.pageIndex, this.permissions.pageSize);
  }

  private getPermissions(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.permissionService.getPermissions(pageIndex, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.permissions = result;
      }, () => { }, () => this.isLoading = false);
  }
}
