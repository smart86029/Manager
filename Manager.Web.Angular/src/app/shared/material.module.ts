import { OverlayModule } from '@angular/cdk/overlay';
import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatExpansionModule,
  MatIconModule,
  MatInputModule,
  MatSidenavModule,
  MatTableModule,
  MatToolbarModule,
  MatGridListModule,
  MatRippleModule,
  MatMenuModule,
} from '@angular/material';

@NgModule({
  exports: [
    MatButtonModule,
    MatButtonToggleModule,
    MatExpansionModule,
    MatIconModule,
    MatSidenavModule,
    MatTableModule,
    MatToolbarModule,
    MatCardModule,
    MatInputModule,
    OverlayModule,
    MatGridListModule,
    MatRippleModule,
    MatMenuModule,
  ]
})
export class MaterialModule { }
