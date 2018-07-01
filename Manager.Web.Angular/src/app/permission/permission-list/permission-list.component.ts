import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';

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
  pageSize = 10;
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
    this.getPermissions(0, this.pageSize);
  }

  private getPermissions(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.permissionService.getPermissions(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      }, () => { }, () => this.isLoading = false);
  }
}
