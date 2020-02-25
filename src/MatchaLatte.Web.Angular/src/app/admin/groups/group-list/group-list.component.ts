import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.scss']
})
export class GroupListComponent implements AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  groups = new PaginationResult<Group>();
  dataSource = new MatTableDataSource<Group>();
  displayedColumns = ['rowId', 'storeName', 'startOn', 'endOn', 'createdOn', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private groupService: GroupService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.groupService.getGroups(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(groups => {
          this.isLoading = false;
          this.isEmptyResult = groups.itemCount === 0;
          this.groups = groups;
          this.dataSource.data = groups.items;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
