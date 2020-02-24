import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { User } from 'src/app/core/user/user';
import { UserService } from 'src/app/core/user/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  users = new PaginationResult<User>();
  dataSource = new MatTableDataSource<User>();
  displayedColumns = ['rowId', 'userName', 'isEnabled', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private userService: UserService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.userService.getUsers(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(users => {
          this.isLoading = false;
          this.isEmptyResult = users.itemCount === 0;
          this.users = users;
          this.dataSource.data = users.items;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
