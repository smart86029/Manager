import { Component, OnInit } from '@angular/core';
import { finalize, tap } from 'rxjs/operators';
import { Order } from 'src/app/core/order/order';
import { OrderService } from 'src/app/core/order/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  isLoading = true;
  isEmptyResult = false;
  orders: Order[] = [];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService
      .getMyOrders()
      .pipe(
        tap(orders => {
          this.orders = orders;
          this.isEmptyResult = orders.length === 0;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
  }
}
