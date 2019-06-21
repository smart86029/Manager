import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/group/group';
import { GroupService } from 'src/app/group/group.service';
import { PaginationResult } from 'src/app/shared/pagination-result';

@Component({
  selector: 'app-member-gallery',
  templateUrl: './member-gallery.component.html',
  styleUrls: ['./member-gallery.component.scss']
})
export class MemberGalleryComponent implements OnInit {
  isGroupsLoading = false;
  groups = new PaginationResult<Group>();

  constructor(private groupService: GroupService) { }

  ngOnInit(): void  {
    this.loadGroups(0, this.groups.pageSize);
  }

  loadGroups(pageIndex: number, pageSize: number): void {
    this.isGroupsLoading = true;
    this.groupService
      .getActiveGroups(pageIndex, pageSize)
      .subscribe({
        next: groups => this.groups = groups,
        complete: () => this.isGroupsLoading = false
      });
  }
}
