import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Location } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatTable } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/shared/guid';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Product } from '../product';
import { ProductCategory } from '../product-category';
import { ProductDetailDialogComponent } from '../product-detail-dialog/product-detail-dialog.component';
import { Store } from '../store';
import { StoreService } from '../store.service';
import { CityService } from 'src/app/city/city.service';
import { City } from 'src/app/city/city';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.scss']
})
export class StoreDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  displayedColumns = ['name', 'price', 'action'];
  store = new Store();
  cities: City[];
  selectCity: City;

  formGroup: FormGroup;
  storeFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  @ViewChild('tableProducts')
  tableProducts: MatTable<Product>;

  constructor(
    private storeService: StoreService,
    private cityService: CityService,
    private route: ActivatedRoute,
    private location: Location,
    private dialog: MatDialog,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.isLoading = true;
      this.storeService.getStore(new Guid(id))
        .subscribe(store => this.store = store, error => { throw error; }, () => this.isLoading = false);
    } else {
      this.storeService.getNewStore()
        .subscribe(store => this.store = store, error => { throw error; }, () => this.isLoading = false);
    }

    this.cityService.getCities()
      .subscribe(cities => {
        this.cities = cities;
        this.selectCity = cities[0];
      });
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
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: product
    });
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        product = data;
      }
    });
  }

  deleteProduct(index: number): void {
    // this.store.products.splice(index, 1);
    // this.tableProducts.renderRows();
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
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
