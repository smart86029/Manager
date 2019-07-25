import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { Guid } from 'src/app/core/guid';
import { PaginationResult } from 'src/app/core/pagination-result';
import { Store } from 'src/app/core/store/store';
import { StoreService } from 'src/app/core/store/store.service';
import { SaveMode } from 'src/app/shared/save-mode/save-mode.enum';

@Component({
  selector: 'app-group-detail',
  templateUrl: './group-detail.component.html',
  styleUrls: ['./group-detail.component.scss']
})
export class GroupDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  group = new Group();
  stores = new PaginationResult<Store>();
  canSelectStore = false;

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
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
      this.canSelectStore = true;
      this.loadStores(0, this.stores.pageSize);
    }
  }

  loadStores(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.storeService
      .getStores(pageIndex, pageSize)
      .subscribe({
        next: stores => this.stores = stores,
        complete: () => this.isLoading = false
      });
  }

  selectStore(store: Store): void {
    this.group.store = store;
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
