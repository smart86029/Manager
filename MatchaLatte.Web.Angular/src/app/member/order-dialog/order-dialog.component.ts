import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderItem } from 'src/app/core/order/order-item';
import { Product } from 'src/app/core/store/product';

@Component({
  selector: 'app-order-dialog',
  templateUrl: './order-dialog.component.html',
  styleUrls: ['./order-dialog.component.scss']
})
export class OrderDialogComponent implements OnInit {
  product = new Product();
  orderItem = new OrderItem();

  constructor(@Inject(MAT_DIALOG_DATA) private data: Product) {
  }

  ngOnInit(): void {
    this.product = this.data;
    this.orderItem.product = this.data;
    this.orderItem.productItem = this.data.productItems[0];
    this.orderItem.quantity = 1;
  }

  addQuantity(): void {
    this.orderItem.quantity++;
  }

  minusQuantity(): void {
    this.orderItem.quantity = Math.max(this.orderItem.quantity - 1, 1);
  }
}
