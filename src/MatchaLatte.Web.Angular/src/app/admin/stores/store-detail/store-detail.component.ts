import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';
import { City } from 'src/app/core/city/city';
import { CityService } from 'src/app/core/city/city.service';
import { District } from 'src/app/core/city/district';
import { Guid } from 'src/app/core/guid';
import { SaveMode } from 'src/app/core/save-mode.enum';
import { Product } from 'src/app/core/store/product';
import { ProductCategory } from 'src/app/core/store/product-category';
import { Store } from 'src/app/core/store/store';
import { StoreService } from 'src/app/core/store/store.service';

import { ProductDetailDialogComponent } from '../product-detail-dialog/product-detail-dialog.component';

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
  logo: File;
  cities: City[];
  selectedCity = new City();
  selectedDistrict: District;

  formGroup: FormGroup;
  storeFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  constructor(
    private storeService: StoreService,
    private cityService: CityService,
    private route: ActivatedRoute,
    private location: Location,
    private dialog: MatDialog,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    let store$ = this.storeService.getNewStore();
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      store$ = this.storeService.getStore(new Guid(id));
    }
    forkJoin([store$, this.cityService.getCities()])
      .pipe(
        tap(([store, cities]) => {
          this.store = store;
          this.cities = cities;
          this.selectedCity = cities.find(city => city.name === store.address.city) || this.cities[0];
          this.selectedDistrict =
            this.selectedCity.districts.find(district => district.name === store.address.district) || this.selectedCity.districts[0];
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe();

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
    this.store.address.city = this.selectedCity.name;
    this.store.address.district = this.selectedDistrict.name;
    let store$ = this.storeService.createStore(this.store);
    if (this.saveMode === SaveMode.Update) {
      store$ = this.storeService.updateStore(this.store, this.logo);
    }
    store$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }

  changeLogo(event: Event): void {
    const element = event.target as HTMLInputElement;
    if (element.files.length > 0) {
      this.logo = element.files[0];
    }
  }

  createProductCategory(): void {
    this.store.productCategories.push(new ProductCategory());
  }

  deleteProductCategory(category: ProductCategory): void {
    const index = this.store.productCategories.indexOf(category);
    this.store.productCategories.splice(index, 1);
  }

  createProduct(category: ProductCategory): void {
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, { data: {} });
    dialogRef
      .afterClosed()
      .pipe(
        tap((result: Product) => {
          if (!!result) {
            category.products.push(result);
          }
        })
      )
      .subscribe();
  }

  updateProduct(product: Product): void {
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, { data: JSON.parse(JSON.stringify(product)) });
    dialogRef
      .afterClosed()
      .pipe(
        tap((result: Product) => {
          if (!!result) {
            product.name = result.name.trim();
            product.productItems = result.productItems;
            product.productItems.forEach(item => item.name = item.name.trim());
          }
        })
      )
      .subscribe();
  }

  deleteProduct(product: Product, category: ProductCategory): void {
    const index = category.products.indexOf(product);
    category.products.splice(index, 1);
  }

  drop(event: CdkDragDrop<string[]>): void {
    moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
  }
}
