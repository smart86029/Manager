import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/core/guid';
import { Order } from 'src/app/core/order/order';
import { OrderItem } from 'src/app/core/order/order-item';
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
  orderItems: OrderItem[];
  totalPrice = 0;
  totalQuantity = 0;
  displayedColumns = ['rowId', 'createdOn', 'productName', 'productItemName', 'quantity', 'action'];
  orderItemColumns = ['select', 'rowId', 'productName', 'productItemName', 'productItemPrice', 'quantity'];
  selection = new SelectionModel<OrderItem>(true, []);

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
              temp[groupKey] = { ...item };
            } else {
              temp[groupKey].quantity += item.quantity;
            }
            this.totalPrice += item.productItemPrice * item.quantity;
            this.totalQuantity += item.quantity;
            return temp;
          }, {});

          this.orderItems = Object.values(groupby);
        },
        complete: () => this.isLoading = false
      });
  }

  isAllSelected() {
    return this.selection.selected.length === this.orderItems.length;
  }

  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.orderItems.forEach(item => this.selection.select(item));
  }
}
