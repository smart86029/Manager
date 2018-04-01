import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';

import { Menu } from '../../menu';
import { Theme } from '../../theme.enum';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit, OnDestroy {
  title = 'Manager';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  menus: Menu[] = [
    { Name: '使用者', Url: '/users' },
    { Name: '角色', Url: '/roles' }
  ];
  showSidenav: MediaQueryList;

  private listener: () => void;

  constructor(private changeDetectorRef: ChangeDetectorRef, private media: MediaMatcher) { }

  ngOnInit(): void {
    this.listener = () => this.changeDetectorRef.detectChanges();
    this.showSidenav = this.media.matchMedia('(min-width: 1600px)');
    this.showSidenav.addListener(this.listener);
  }

  ngOnDestroy(): void {
    this.showSidenav.removeListener(this.listener);
  }

  changeTheme(theme: Theme): void {
    this.selectedTheme = theme;
  }
}
