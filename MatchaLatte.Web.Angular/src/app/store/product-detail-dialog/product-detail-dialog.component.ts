import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Product } from '../product';
import { ProductItem } from '../product-item';

@Component({
  selector: 'app-product-detail-dialog',
  templateUrl: './product-detail-dialog.component.html',
  styleUrls: ['./product-detail-dialog.component.scss']
})
export class ProductDetailDialogComponent implements OnInit {
  saveMode = SaveMode.Create;

  constructor(@Inject(MAT_DIALOG_DATA) private data: Product) { }

  ngOnInit(): void {
    if (this.data.name) {
      this.saveMode = SaveMode.Update;
    } else {
      this.data = new Product();
      this.createProductItem();
    }
  }

  createProductItem(): void {
    this.data.productItems.push(new ProductItem());
  }

  deleteProductItem(index: number): void {
    this.data.productItems.splice(index, 1);
  }
}
