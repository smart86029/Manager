import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatButtonToggleModule,
  MatExpansionModule,
  MatIconModule,
  MatSidenavModule,
  MatTableModule,
  MatToolbarModule,
  MatCardModule,
  MatInputModule
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
    MatInputModule
  ]
})
export class MaterialModule { }
