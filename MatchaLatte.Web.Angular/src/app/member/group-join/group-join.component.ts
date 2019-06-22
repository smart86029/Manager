import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { Guid } from 'src/app/shared/guid';
import { Product } from 'src/app/store/product';
import { StoreService } from 'src/app/store/store.service';

import { Group } from '../../group/group';
import { GroupService } from '../../group/group.service';
import { Store } from '../../group/store';
import { OrderDialogComponent } from '../order-dialog/order-dialog.component';

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
    this.groupService
      .getGroup(new Guid(id))
      .pipe(
        tap(group => this.group = group),
        switchMap(group => this.storeService.getStore(group.store.id)))
      .subscribe({
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
