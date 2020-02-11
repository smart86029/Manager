import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { RoleService } from 'src/app/core/role/role.service';
import { Role } from 'src/app/core/user/role';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit, AfterViewInit {
  isLoading = false;
  roles = new PaginationResult<Role>();
  dataSource = new MatTableDataSource<Role>();
  displayedColumns = ['rowId', 'name', 'isEnabled', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.roleService.getRoles(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isLoading = false)
      )
      .subscribe({
        next: roles => {
          this.roles = roles;
          this.dataSource.data = roles.items;
        },
      });
  }
}
