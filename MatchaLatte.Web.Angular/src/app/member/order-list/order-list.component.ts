import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/core/order/order.service';
import { Order } from 'src/app/core/order/order';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  isLoading = false;
  orders: Order[] = [];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService
      .getMyOrders()
      .subscribe({
        next: orders => this.orders = orders,
        complete: () => this.isLoading = false
      });
  }
}
