import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';

@NgModule({
  declarations: [UserListComponent, UserDetailComponent],
  imports: [
    SharedModule,
  ]
})
export class UserModule { }
