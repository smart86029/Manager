import { AfterViewInit, Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { from, Subscription } from 'rxjs';
import { startWith, switchMap, tap, finalize } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-member-gallery',
  templateUrl: './member-gallery.component.html',
  styleUrls: ['./member-gallery.component.scss']
})
export class MemberGalleryComponent implements AfterViewInit, OnDestroy {
  isGroupsLoading = false;
  groups = new PaginationResult<Group>();

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private groupService: GroupService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isGroupsLoading = true),
        switchMap(() => this.groupService.getActiveGroups(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(groups => {
          this.isGroupsLoading = false;
          this.groups = groups;
        }),
        finalize(() => this.isGroupsLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
