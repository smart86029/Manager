import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderItem } from 'src/app/core/order/order-item';
import { Product } from 'src/app/core/store/product';
import { ProductItem } from 'src/app/core/store/product-item';

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
    this.orderItem.productId = this.product.id;
    this.orderItem.productName = this.product.name;
    this.orderItem.quantity = 1;
    this.selectProductItem(this.product.productItems[0]);
  }

  selectProductItem(productItem: ProductItem): void {
    this.orderItem.productItemId = productItem.id;
    this.orderItem.productItemName = productItem.name;
    this.orderItem.productItemPrice = productItem.price;
  }

  addQuantity(): void {
    this.orderItem.quantity++;
  }

  minusQuantity(): void {
    this.orderItem.quantity = Math.max(this.orderItem.quantity - 1, 1);
  }
}
