import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';

import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<Role>();
  pageSize = 10;
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
    this.getRoles(0, this.pageSize);
  }

  private getRoles(pageIndex: number, pageSize: number): void {
    this.roleService.getRoles(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      });
  }
}
