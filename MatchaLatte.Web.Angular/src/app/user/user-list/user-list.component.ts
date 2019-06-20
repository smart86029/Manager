import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/shared/pagination-result';

import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  isLoading = false;
  users = new PaginationResult<User>();
  dataSource = new MatTableDataSource<User>();
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsers(this.users.pageIndex, this.users.pageSize);
  }

  loadUsers(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.userService
      .getUsers(pageIndex, pageSize)
      .subscribe({
        next: users => {
          this.users = users;
          this.dataSource.data = users.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
