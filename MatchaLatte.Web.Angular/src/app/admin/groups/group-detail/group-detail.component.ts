import { Location } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { Guid } from 'src/app/core/guid';
import { PaginationResult } from 'src/app/core/pagination-result';
import { SaveMode } from 'src/app/core/save-mode.enum';
import { Store } from 'src/app/core/store/store';
import { StoreService } from 'src/app/core/store/store.service';

@Component({
  selector: 'app-group-detail',
  templateUrl: './group-detail.component.html',
  styleUrls: ['./group-detail.component.scss']
})
export class GroupDetailComponent implements OnInit, AfterViewInit {
  isLoading = false;
  pageEvent: PageEvent;
  saveMode = SaveMode.Create;
  group = new Group();
  stores = new PaginationResult<Store>();
  canSelectStore = false;

  @ViewChild(MatPaginator, { static: false })
  paginator: MatPaginator;

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
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
    }
  }

  ngAfterViewInit(): void {
    if (this.canSelectStore) {
      from(this.paginator.page)
        .pipe(
          startWith({}),
          tap(() => this.isLoading = true),
          switchMap(() => this.storeService.getStores(this.paginator.pageIndex, this.paginator.pageSize)),
          tap(() => this.isLoading = false)
        )
        .subscribe({
          next: stores => this.stores = stores,
        });
    }
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
