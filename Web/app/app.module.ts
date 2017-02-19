import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard.component';
import { RoleDetailComponent } from './roles/role-detail.component';
import { RolesComponent } from './roles/roles.component';
import { RoleService } from './roles/role.service';
import { UserListComponent } from './users/user-list.component';
import { UserService } from './users/user.service';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    RoleDetailComponent,
    RolesComponent,
    UserListComponent
  ],
  providers: [
    RoleService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
