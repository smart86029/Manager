import { Component, OnInit } from '@angular/core';

import { Menu } from '../../menu';
import { Theme } from '../../theme.enum';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  title = 'Manager';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  menus: Menu[] = [
    { Name: '使用者', Url: '/users' },
    { Name: '角色', Url: './roles' }
  ];

  constructor() { }

  ngOnInit() {
  }

  changeTheme(theme: Theme) {
    this.selectedTheme = theme;
  }
}
