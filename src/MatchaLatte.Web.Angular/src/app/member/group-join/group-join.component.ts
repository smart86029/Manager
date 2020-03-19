import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, Subscription } from 'rxjs';
import { finalize, switchMap, tap } from 'rxjs/operators';
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
export class GroupJoinComponent implements OnInit, OnDestroy {
  isLoading = true;
  group = new Group();
  store = new Store();
  order = new Order();
  productItemNames: string[] = [];
  orderItemsChanged$ = new Subject();
  total = 0;

  private subscription = new Subscription();

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.groupService
      .getGroup(new Guid(id))
      .pipe(
        tap(group => {
          this.group = group;
          this.order.groupId = group.id;
        }),
        switchMap(group => this.storeService.getStore(group.store.id)),
        tap(store => {
          this.store = store;
          this.mapProductItem()
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
    this.subscription.add(this.orderItemsChanged$
      .pipe(
        tap(() => {
          let temp = 0;
          this.order.orderItems.map(item => temp += item.productItemPrice * item.quantity);
          this.total = temp;
        })
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  selectProduct(product: Product): void {
    this.dialog
      .open(OrderDialogComponent, { data: product })
      .afterClosed()
      .pipe(
        tap((orderItem: OrderItem) => {
          if (orderItem) {
            this.order.orderItems.push(orderItem);
            this.orderItemsChanged$.next();
          }
        })
      )
      .subscribe();
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
      .pipe(
        tap(order => this.router.navigate(['orders']))
      )
      .subscribe();
  }

  getPrice(name: string, product: Product): string {
    return product.productItems.find(x => x.name === name)?.price.toString() || '';
  }

  private mapProductItem(): void {
    const all = this.store.productCategories
      .flatMap(category => category.products)
      .flatMap(product => product.productItems)
      .map(productItem => productItem.name);
    const distincted = new Set(all);
    if (distincted.size < 5) {
      this.productItemNames = [...distincted];
      for (let i = 0; i < 5 - distincted.size; i++) {
        this.productItemNames.unshift('');
      }
    } else {
      this.productItemNames = [...distincted].slice(0, 4);
      this.productItemNames.push('...');
    }
  }
}
