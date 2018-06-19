import { Injectable } from '@angular/core';
import { PermissionModule } from './permission.module';

@Injectable({
  providedIn: PermissionModule
})
export class PermissionService {

  constructor() { }
}
