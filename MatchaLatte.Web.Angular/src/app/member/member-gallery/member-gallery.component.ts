import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-member-gallery',
  templateUrl: './member-gallery.component.html',
  styleUrls: ['./member-gallery.component.scss']
})
export class MemberGalleryComponent implements OnInit, AfterViewInit {
  isGroupsLoading = false;
  groups = new PaginationResult<Group>();

  @ViewChild(MatPaginator, { static: false })
  paginator: MatPaginator;

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isGroupsLoading = true),
        switchMap(() => this.groupService.getActiveGroups(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isGroupsLoading = false)
      )
      .subscribe({
        next: groups => this.groups = groups,
      });
  }
}
