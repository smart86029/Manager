import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard.component';
import { RoleDetailComponent } from './roles/role-detail.component';
import { RolesComponent } from './roles/roles.component';
import { RoleService } from './roles/role.service';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    RoleDetailComponent,
    RolesComponent
  ],
  providers: [RoleService],
  bootstrap: [AppComponent]
})
export class AppModule { }