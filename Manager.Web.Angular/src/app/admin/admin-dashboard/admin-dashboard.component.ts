import { Component, OnInit } from '@angular/core';

import { Menu } from '../../menu';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  title = 'Manager';
  menus: Menu[] = [
    { Name: '使用者', Url: '/users' },
    { Name: '角色', Url: '/roles' }
  ];

  constructor() { }

  ngOnInit() {
  }

}
