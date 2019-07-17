import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { Order } from 'src/app/order/order';
import { OrderService } from 'src/app/order/order.service';
import { Guid } from 'src/app/shared/guid';
import { Product } from 'src/app/store/product';
import { StoreService } from 'src/app/store/store.service';

import { Group } from '../../group/group';
import { GroupService } from '../../group/group.service';
import { Store } from '../../group/store';
import { OrderDialogComponent } from '../order-dialog/order-dialog.component';
import { OrderItem } from 'src/app/order/order-item';

@Component({
  selector: 'app-group-join',
  templateUrl: './group-join.component.html',
  styleUrls: ['./group-join.component.scss']
})
export class GroupJoinComponent implements OnInit {
  isLoading = false;
  group = new Group();
  store = new Store();
  order = new Order();
  orderItemsChanged$ = new Subject();
  total = 0;

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    this.groupService
      .getGroup(new Guid(id))
      .pipe(
        tap(group => {
          this.group = group;
          this.order.groupId = group.id;
        }),
        switchMap(group => this.storeService.getStore(group.store.id)))
      .subscribe({
        next: store => this.store = store,
        complete: () => this.isLoading = false
      });
    this.orderItemsChanged$
      .subscribe({
        next: () => {
          let temp = 0;
          this.order.orderItems.map(item => temp += item.productItem.price * item.quantity);
          this.total = temp;
        }
      });
  }

  selectProduct(product: Product): void {
    this.dialog
      .open(OrderDialogComponent, {
        data: product
      })
      .afterClosed()
      .subscribe({
        next: item => {
          if (item) {
            this.order.orderItems.push(item);
            this.orderItemsChanged$.next();
          }
        }
      });
  }

  deleteOrderItem(orderItem: OrderItem): void {
    const index = this.order.orderItems.indexOf(orderItem);
    this.order.orderItems.splice(index, 1);
    this.orderItemsChanged$.next();
  }

  save(): void {
    if (this.order.orderItems.length === 0) {
      this.snackBar.open('請選擇商品項目');
    }
    this.orderService
      .createOrder(this.order)
      .subscribe({
        next: order => this.router.navigate(['/'])
      });
  }
}
