import { Component, OnInit, ViewChild } from '@angular/core';

import { User } from '../user';
import { UserService } from '../user.service';
import { MatPaginator, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<User>();

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
    this.dataSource.paginator = this.paginator;
  }

  private getUsers(): void {
    this.userService.getUsers()
      .subscribe(users => this.dataSource.data = users);
  }
}
