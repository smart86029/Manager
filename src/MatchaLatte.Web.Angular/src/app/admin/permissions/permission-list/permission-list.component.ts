import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { Permission } from 'src/app/core/permission/permission';
import { PermissionService } from 'src/app/core/permission/permission.service';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styleUrls: ['./permission-list.component.scss']
})
export class PermissionListComponent implements OnInit, AfterViewInit {
  isLoading: boolean;
  permissions = new PaginationResult<Permission>();
  dataSource = new MatTableDataSource<Permission>();
  displayedColumns = ['rowId', 'code', 'name', 'isEnabled', 'action'];

  @ViewChild(MatPaginator, { static: false })
  paginator: MatPaginator;

  constructor(private permissionService: PermissionService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.permissionService.getPermissions(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isLoading = false)
      )
      .subscribe({
        next: permissions => {
          this.permissions = permissions;
          this.dataSource.data = permissions.items;
        },
      });
  }
}
