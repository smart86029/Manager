import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';

@Component({
  selector: 'app-product-detail-dialog',
  templateUrl: './product-detail-dialog.component.html',
  styleUrls: ['./product-detail-dialog.component.scss']
})
export class ProductDetailDialogComponent implements OnInit {
  saveMode = SaveMode.Create;
  constructor(@Inject(MAT_DIALOG_DATA) private data: any) { }

  ngOnInit() {
    if (this.data.productId > 0) {
      this.saveMode = SaveMode.Update;
    }
  }
}
