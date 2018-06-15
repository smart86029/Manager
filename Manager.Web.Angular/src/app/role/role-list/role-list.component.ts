import { Component, AfterViewInit, ViewChild } from '@angular/core';

import { Role } from '../role';
import { RoleService } from '../role.service';
import { MatTableDataSource, MatPaginator, PageEvent } from '@angular/material';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements AfterViewInit {
  displayedColumns = ['id', 'name', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<Role>();
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private roleService: RoleService) { }

  ngAfterViewInit(): void {
    this.getRoles();
  }

  private getRoles(): void {
    this.roleService.getRoles(this.paginator.pageIndex + 1, +this.paginator.pageSize)
      .subscribe(roles => {
        this.dataSource.data = roles.items;
        this.itemCount = roles.itemCount;
      });
  }
}
