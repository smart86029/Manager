import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthGuard } from './auth.guard';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignInRoutingModule } from './sign-in/sign-in-routing.module';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    SignInRoutingModule
  ],
  providers: [
  ],
  declarations: [SignInComponent]
})
export class CoreModule { }
