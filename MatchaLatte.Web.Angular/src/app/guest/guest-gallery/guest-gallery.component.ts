import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/group/group';
import { GroupService } from 'src/app/group/group.service';
import { Store } from 'src/app/store/store';
import { StoreService } from 'src/app/store/store.service';

@Component({
  selector: 'app-guest-gallery',
  templateUrl: './guest-gallery.component.html',
  styleUrls: ['./guest-gallery.component.scss']
})
export class GuestGalleryComponent implements OnInit {
  isGroupsLoading = false;
  isStoresLoading = false;
  groups: Group[];
  stores: Store[];

  constructor(private groupService: GroupService, private storeService: StoreService) { }

  ngOnInit(): void {
    this.getGroups();
    this.getStores();
  }

  private getGroups(): void {
    this.isGroupsLoading = true;
    this.groupService
      .getActiveGroups()
      .subscribe({
        next: result => this.groups = result,
        complete: () => this.isGroupsLoading = false
      });
  }

  private getStores(): void {
    this.isStoresLoading = true;
    this.storeService
      .getStores(0, 10)
      .subscribe({
        next: result => this.stores = result.items,
        complete: () => this.isStoresLoading = false
      });
  }
}
