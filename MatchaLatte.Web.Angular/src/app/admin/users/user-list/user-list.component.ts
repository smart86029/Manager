import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { User } from 'src/app/core/user/user';
import { UserService } from 'src/app/core/user/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit, AfterViewInit {
  isLoading = false;
  users = new PaginationResult<User>();
  dataSource = new MatTableDataSource<User>();
  displayedColumns = ['rowId', 'userName', 'isEnabled', 'action'];

  @ViewChild(MatPaginator, { static: false })
  paginator: MatPaginator;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.userService.getUsers(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isLoading = false)
      )
      .subscribe({
        next: users => {
          this.users = users;
          this.dataSource.data = users.items;
        },
      });
  }
}
