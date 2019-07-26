import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { Group } from 'src/app/core/group/group';
import { GroupService } from 'src/app/core/group/group.service';
import { Guid } from 'src/app/core/guid';
import { Order } from 'src/app/core/order/order';
import { OrderItem } from 'src/app/core/order/order-item';
import { OrderService } from 'src/app/core/order/order.service';
import { Product } from 'src/app/core/store/product';
import { Store } from 'src/app/core/store/store';
import { StoreService } from 'src/app/core/store/store.service';

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
          this.order.orderItems.map(item => temp += item.productItemPrice * item.quantity);
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
