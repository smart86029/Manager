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
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<Permission>();
  pageSize = 10;
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
    console.log(1);
    this.getPermissions(0, this.pageSize);
  }

  private getPermissions(pageIndex: number, pageSize: number): void {
    this.permissionService.getPermissions(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      });
  }
}
