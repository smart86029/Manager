import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';

import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<User>();
  pageSize = 5;
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers(0, this.pageSize);
  }

  private getUsers(pageIndex: number, pageSize: number): void {
    this.userService.getUsers(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      });
  }
}
