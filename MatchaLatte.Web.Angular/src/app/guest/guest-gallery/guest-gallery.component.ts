import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/store/store';
import { StoreService } from 'src/app/store/store.service';

@Component({
  selector: 'app-guest-gallery',
  templateUrl: './guest-gallery.component.html',
  styleUrls: ['./guest-gallery.component.scss']
})
export class GuestGalleryComponent implements OnInit {
  isLoading = false;
  stores: Store[];

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.getStores();
  }

  private createGroup(store: Store) {
    console.log(store.name);
  }

  private getStores(): void {
    this.isLoading = true;
    this.storeService.getStores(0, 100).subscribe({
      next: result => {
        this.stores = result.items;
      }, complete: () => this.isLoading = false
    });
  }
}
