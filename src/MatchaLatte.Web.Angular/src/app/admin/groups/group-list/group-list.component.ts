import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.scss']
})
export class GroupListComponent implements OnInit, AfterViewInit {
  isLoading = true;
  groups = new PaginationResult<Group>();
  dataSource = new MatTableDataSource<Group>();
  displayedColumns = ['rowId', 'storeName', 'startOn', 'endOn', 'createdOn', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.groupService.getGroups(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isLoading = false)
      )
      .subscribe({
        next: groups => {
          this.groups = groups;
          this.dataSource.data = groups.items;
        },
      });
  }
}
