import { Location } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatTable } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Product } from '../product';
import { ProductDetailDialogComponent } from '../product-detail-dialog/product-detail-dialog.component';
import { Store } from '../store';
import { StoreService } from '../store.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ProductCategory } from '../product-category';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.scss']
})
export class StoreDetailComponent implements OnInit {
  isLoading = true;
  saveMode = SaveMode.Create;
  displayedColumns = ['name', 'price', 'action'];
  store = new Store();

  formGroup: FormGroup;
  storeFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  @ViewChild('tableProducts')
  tableProducts: MatTable<Product>;

  constructor(
    private storeService: StoreService,
    private route: ActivatedRoute,
    private location: Location,
    private dialog: MatDialog,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.isLoading = true;
      this.storeService.getStore(id)
        .subscribe(store => this.store = store, () => { }, () => this.isLoading = false);
    } else {
      this.storeService.getNewStore()
        .subscribe(store => this.store = store, () => { }, () => this.isLoading = false);
    }

    this.formGroup = new FormGroup({
      storeFormGroup: this.formBuilder.group({
        firstCtrl: ['', Validators.required]
      }),
      secondFormGroup: this.formBuilder.group({
        secondCtrl: ['', Validators.required]
      })
    });
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

  createProductCategory(): void {
    this.store.productCategories.push(new ProductCategory());
  }

  createProduct(category: ProductCategory): void {
    console.log(category);
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: {}
    });
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        category.products.push(data);
      }
    });
  }

  updateProduct(product: Product): void {
    // const dialogRef = this.dialog.open(ProductDetailDialogComponent, {
    //   data: {
    //     name: product.name,
    //     price: product.price
    //   }
    // });
    // dialogRef.afterClosed().subscribe(data => {
    //   if (data) {
    //     product.name = data.name;
    //     product.price = data.price;
    //   }
    // });
  }

  deleteProduct(index: number): void {
    // this.store.products.splice(index, 1);
    // this.tableProducts.renderRows();
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
