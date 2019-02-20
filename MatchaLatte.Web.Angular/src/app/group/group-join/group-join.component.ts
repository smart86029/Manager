import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { Guid } from 'src/app/shared/guid';
import { StoreService } from 'src/app/store/store.service';

import { Group } from '../group';
import { GroupService } from '../group.service';
import { Store } from '../store';
import { MatDialog } from '@angular/material';
import { OrderDialogComponent } from '../order-dialog/order-dialog.component';
import { Product } from 'src/app/store/product';

@Component({
  selector: 'app-group-join',
  templateUrl: './group-join.component.html',
  styleUrls: ['./group-join.component.scss']
})
export class GroupJoinComponent implements OnInit {
  isLoading = false;
  group = new Group();
  store = new Store();

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private route: ActivatedRoute,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    this.groupService.getGroup(new Guid(id)).pipe(
      tap(group => this.group = group),
      switchMap(group => this.storeService.getStore(group.store.storeId))
    ).subscribe({
      next: store => this.store = store,
      complete: () => this.isLoading = false
    });
  }

  createOrder(product: Product): void {
    const dialogRef = this.dialog.open(OrderDialogComponent, {
      data: product
    });
  }
}
