import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatIconModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatRippleModule,
  MatSidenavModule,
  MatToolbarModule,
  MatTableModule,
  MatExpansionModule,
} from '@angular/material';

@NgModule({
  exports: [
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTableModule,
    MatToolbarModule,
    MatSidenavModule,
    MatExpansionModule,
  ]
})
export class MaterialModule { }
