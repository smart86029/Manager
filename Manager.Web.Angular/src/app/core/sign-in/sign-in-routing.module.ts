import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../auth.guard';
import { AuthService } from '../auth.service';
import { SignInComponent } from './sign-in.component';

const routes: Routes = [
  { path: 'signin', component: SignInComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
    AuthGuard,
    AuthService
  ]
})
export class SignInRoutingModule { }
