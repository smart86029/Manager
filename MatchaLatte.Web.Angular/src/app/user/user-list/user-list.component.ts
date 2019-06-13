import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';
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
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<User>();
  users = new PaginationResult<User>();

  constructor(private userService: UserService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.getUsers(this.users.pageIndex, this.users.pageSize);
  }

  private getUsers(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.userService.getUsers(pageIndex, pageSize).subscribe({
      next: result => {
        this.dataSource.data = result.items;
        this.users = result;
      },
      complete: () => this.isLoading = false
    });
  }
}
