import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { RoleService } from 'src/app/core/role/role.service';
import { Role } from 'src/app/core/user/role';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  roles = new PaginationResult<Role>();
  dataSource = new MatTableDataSource<Role>();
  displayedColumns = ['rowId', 'name', 'isEnabled', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private roleService: RoleService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.roleService.getRoles(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(roles => {
          this.isLoading = false;
          this.isEmptyResult = roles.itemCount === 0;
          this.roles = roles;
          this.dataSource.data = roles.items;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
