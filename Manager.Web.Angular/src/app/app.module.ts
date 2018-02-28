import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { RolesComponent } from './roles/roles.component';
import { RoleService } from './roles/role.service';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './shared/material.module';


@NgModule({
  declarations: [
    AppComponent,
    RolesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [
    RoleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
