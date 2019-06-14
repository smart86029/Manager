import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/shared/guid';
import { SaveMode } from 'src/app/shared/save-mode/save-mode.enum';

import { Group } from '../group';
import { GroupService } from '../group.service';

@Component({
  selector: 'app-group-detail',
  templateUrl: './group-detail.component.html',
  styleUrls: ['./group-detail.component.scss']
})
export class GroupDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  group = new Group();

  constructor(
    private groupService: GroupService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.groupService
        .getGroup(new Guid(id))
        .subscribe({
          next: group => this.group = group,
          complete: () => this.isLoading = false
        });
    } else {
      const storeId = this.route.snapshot.queryParamMap.get('storeId');
      this.groupService
        .getNewGroup(new Guid(storeId))
        .subscribe({
          next: group => this.group = group,
          complete: () => this.isLoading = false
        });
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.groupService
      .createGroup(this.group)
      .subscribe(group => this.location.back());
  }

  private update(): void {
    this.groupService
      .updateGroup(this.group)
      .subscribe(group => this.location.back());
  }
}
