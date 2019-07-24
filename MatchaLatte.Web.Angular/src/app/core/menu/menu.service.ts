import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Menu } from './menu';

const menus: Menu[] = [
  {
    name: '會員管理', icon: 'group', url: '', children: [
      { name: '使用者', icon: '', url: 'users' },
      { name: '角色', icon: '', url: 'roles' },
      { name: '權限', icon: '', url: 'permissions' }
    ]
  },
  {
    name: '目錄管理', icon: 'store', url: '', children: [
      { name: '店家管理', icon: '', url: 'stores' },
      { name: '團管理', icon: '', url: 'groups' }
    ]
  }
];

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  menus$: BehaviorSubject<Menu[]> = new BehaviorSubject<Menu[]>([]);

  constructor() {
    this.menus$.next(menus);
  }
}
