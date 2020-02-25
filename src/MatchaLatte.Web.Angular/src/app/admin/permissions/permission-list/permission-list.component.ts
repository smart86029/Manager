import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { Permission } from 'src/app/core/permission/permission';
import { PermissionService } from 'src/app/core/permission/permission.service';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styleUrls: ['./permission-list.component.scss']
})
export class PermissionListComponent implements AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  permissions = new PaginationResult<Permission>();
  dataSource = new MatTableDataSource<Permission>();
  displayedColumns = ['rowId', 'code', 'name', 'isEnabled', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private permissionService: PermissionService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.permissionService.getPermissions(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(permissions => {
          this.isLoading = false;
          this.isEmptyResult = permissions.itemCount === 0;
          this.permissions = permissions;
          this.dataSource.data = permissions.items;
        })
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
