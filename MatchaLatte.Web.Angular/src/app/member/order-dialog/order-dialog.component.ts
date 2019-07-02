import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderItem } from 'src/app/order/order-item';
import { Product } from 'src/app/store/product';

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
  }
}
