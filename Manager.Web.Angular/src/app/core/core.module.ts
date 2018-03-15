import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthGuard } from './auth.guard';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignInRoutingModule } from './sign-in/sign-in-routing.module';
import { SharedModule } from '../shared/shared.module';
@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    SignInRoutingModule
  ],
  providers: [
  ],
  declarations: [SignInComponent]
})
export class CoreModule { }
