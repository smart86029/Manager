import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Menu } from './menu';

const menus: Menu[] = [
  {
    name: '會員管理', icon: 'group', url: '', children: [
      { name: '使用者', icon: '', url: '/admin/users' },
      { name: '角色', icon: '', url: '/admin/roles' },
      { name: '權限', icon: '', url: '/admin/permissions' }
    ]
  },
  {
    name: '團購管理', icon: 'shopping_basket', url: '', children: [
      { name: '店家管理', icon: '', url: '/admin/stores' },
      { name: '團管理', icon: '', url: '/admin/groups' }
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
