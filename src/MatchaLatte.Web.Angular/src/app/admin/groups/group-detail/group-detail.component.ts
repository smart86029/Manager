import { Location } from '@angular/common';
import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
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
export class GroupDetailComponent implements OnInit, AfterViewInit, OnDestroy {
  isLoading = true;
  canSelectStore = true;
  saveMode = SaveMode.Create;
  group = new Group();
  stores = new PaginationResult<Store>();

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.isLoading = true;
      this.canSelectStore = false;
      this.saveMode = SaveMode.Update;
      this.groupService
        .getGroup(new Guid(id))
        .pipe(
          tap(group => this.group = group),
          finalize(() => this.isLoading = false)
        )
        .subscribe();
    }
  }

  ngAfterViewInit(): void {
    if (this.canSelectStore) {
      this.subscription.add(this.paginator.page
        .pipe(
          startWith({}),
          tap(() => this.isLoading = true),
          switchMap(() => this.storeService.getStores(this.paginator.pageIndex, this.paginator.pageSize)),
          tap(stores => {
            this.isLoading = false;
            this.stores = stores;
          }),
          finalize(() => this.isLoading = false)
        )
        .subscribe());
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  selectStore(store: Store): void {
    this.group.store = store;
  }

  save(): void {
    let group$ = this.groupService.createGroup(this.group);
    if (this.saveMode === SaveMode.Update) {
      group$ = this.groupService.updateGroup(this.group);
    }
    group$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }
}
