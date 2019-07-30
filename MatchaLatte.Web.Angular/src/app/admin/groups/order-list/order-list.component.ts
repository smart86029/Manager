import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/core/guid';
import { Order } from 'src/app/core/order/order';
import { OrderService } from 'src/app/core/order/order.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  isLoading = false;
  groupId: Guid;
  orders = new PaginationResult<Order>();
  dataSource = new MatTableDataSource<Order>();
  displayedColumns = ['rowId', 'createdOn', 'productName', 'productItemName', 'quantity', 'action'];

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService) { }

  ngOnInit() {
    this.groupId = new Guid(this.route.snapshot.paramMap.get('id'));
    this.loadOrders(0, this.orders.pageSize);
  }

  loadOrders(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.orderService
      .getOrders(this.groupId, pageIndex, pageSize)
      .subscribe({
        next: orders => {
          this.orders = orders;
          this.dataSource.data = orders.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
