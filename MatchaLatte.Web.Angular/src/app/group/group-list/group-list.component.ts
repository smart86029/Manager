import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/shared/pagination-result';

import { Group } from '../group';
import { GroupService } from '../group.service';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.scss']
})
export class GroupListComponent implements OnInit {
  isLoading = false;
  groups = new PaginationResult<Group>();
  dataSource = new MatTableDataSource<Group>();
  displayedColumns = ['rowId', 'storeName', 'startOn', 'endOn', 'createdOn', 'action'];

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
    this.loadGroups(0, this.groups.pageSize);
  }

  loadGroups(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.groupService
      .getGroups(pageIndex, pageSize)
      .subscribe({
        next: groups => {
          this.groups = groups;
          this.dataSource.data = groups.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
