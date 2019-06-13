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
  displayedColumns = ['id', 'storeName', 'startTime', 'endTime', 'createdOn', 'action'];
  dataSource = new MatTableDataSource<Group>();
  groups = new PaginationResult<Group>();

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
    this.getGroups(0, this.groups.pageSize);
  }

  private getGroups(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.groupService
      .getGroups(pageIndex, pageSize)
      .subscribe({
        next: result => {
          this.dataSource.data = result.items;
          this.groups = result;
        },
        complete: () => this.isLoading = false
      });
  }
}
