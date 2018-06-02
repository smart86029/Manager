import { Injectable } from '@angular/core';
import { Menu } from './menu';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  menus: Menu[] = [
    {
      name: '會員管理', icon: 'group', url: '', children: [
        { name: '使用者', icon: '', url: '/users', children: null },
        { name: '角色', icon: '', url: '/roles', children: null }
      ]
    },
    {
      name: '團購管理', icon: 'shopping_basket', url: '', children: [
        { name: '店家管理', icon: '', url: '/stores', children: null }
      ]
    }
  ];
  dataChange: BehaviorSubject<Menu[]> = new BehaviorSubject<Menu[]>([]);

  constructor() {
    this.dataChange.next(this.menus);
  }

  getData(): Menu[] {
    return this.dataChange.value;
  }
}
