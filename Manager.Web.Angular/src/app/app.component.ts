import { Component } from '@angular/core';

import { Menu } from './menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Manager';
  menus: Menu[] = [
    { Name: '使用者', Url: '/users' },
    { Name: '角色', Url: '/roles' }
  ];
}
