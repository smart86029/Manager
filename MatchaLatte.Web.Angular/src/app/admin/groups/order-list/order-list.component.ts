import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/core/guid';
import { Order } from 'src/app/core/order/order';
import { OrderService } from 'src/app/core/order/order.service';
import { OrderItem } from 'src/app/core/order/order-item';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  isLoading = false;
  groupId: Guid;
  orders: Order[];
  orderItems: OrderItem[];
  displayedColumns = ['rowId', 'createdOn', 'productName', 'productItemName', 'quantity', 'action'];
  orderItemColumns = ['rowId', 'productName', 'productItemName', 'quantity'];

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
        next: orders => {
          this.orders = orders;
          const orderItems = orders.reduce((temp: OrderItem[], order) => temp.concat(order.orderItems), []);
          const groupby = orderItems.reduce((temp, item) => {
            const groupKey = item.productItemId.toString();
            if (!temp[groupKey]) {
              temp[groupKey] = {...item};
            } else {
              temp[groupKey].quantity += item.quantity;
            }
            return temp;
          }, {});

          this.orderItems = Object.values(groupby);
        },
        complete: () => this.isLoading = false
      });
  }
}
