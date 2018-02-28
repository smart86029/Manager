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
} from '@angular/material';

@NgModule({
  imports:[
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTableModule
  ],
  exports:[
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTableModule
  ]
})
export class MaterialModule { }
