import { Component, ComponentFactoryResolver, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';

import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  isLoading: boolean;
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<User>();
  pageSize = 10;
  itemCount = 0;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private userService: UserService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.getUsers(0, this.pageSize);
  }

  private getUsers(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.userService.getUsers(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      }, () => { }, () => this.isLoading = false);
  }
}
