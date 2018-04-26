import { Location } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatTable } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Product } from '../product';
import { ProductDetailDialogComponent } from '../product-detail-dialog/product-detail-dialog.component';
import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.scss']
})
export class StoreDetailComponent implements OnInit {
  @ViewChild('tableProducts')
  tableProducts: MatTable<Product>;
  displayedColumns = ['name', 'price', 'action'];
  saveMode = SaveMode.Create;
  store = new Store();
  isLoading = true;

  constructor(
    private storeService: StoreService,
    private route: ActivatedRoute,
    private location: Location,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.storeService.getStore(id)
        .subscribe(store => this.store = store, () => { }, () => this.isLoading = false);
    } else {
      this.storeService.getNewStore()
        .subscribe(store => this.store = store, () => { }, () => this.isLoading = false);
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  createProduct(): void {
    let dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: {}
    });
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        const product = new Product();
        product.name = data.name;
        product.price = data.price;
        this.store.products.push(product);
        this.tableProducts.renderRows();
      }
    });
  }

  updateProduct(product: Product): void {
    let dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: {
        name: product.name,
        price: product.price
      }
    });
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        product.name = data.name;
        product.price = data.price;
      }
    });
  }

  deleteProduct(index: number): void {
    this.store.products.splice(index, 1);
    this.tableProducts.renderRows();
  }

  private create(): void {
    this.storeService.createStore(this.store)
      .subscribe(store => this.location.back());
  }

  private update(): void {
    this.storeService.updateStore(this.store)
      .subscribe(store => this.location.back());
  }
}
