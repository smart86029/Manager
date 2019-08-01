import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/core/guid';
import { Order } from 'src/app/core/order/order';
import { OrderService } from 'src/app/core/order/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  isLoading = false;
  groupId: Guid;
  orders: Order[];
  displayedColumns = ['rowId', 'createdOn', 'productName', 'productItemName', 'quantity', 'action'];

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService) { }

  ngOnInit(): void {
    this.groupId = new Guid(this.route.snapshot.paramMap.get('id'));
    this.loadOrders();
  }

  loadOrders(): void {
    this.isLoading = true;
    this.orderService
      .getGroupOrders(this.groupId)
      .subscribe({
        next: orders => this.orders = orders,
        complete: () => this.isLoading = false
      });
  }
}
