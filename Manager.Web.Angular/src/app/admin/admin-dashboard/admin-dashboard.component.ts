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
  private mobileQueryListener: () => void;

  title = 'Manager';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  menus: Menu[] = [
    { Name: '使用者', Url: '/users' },
    { Name: '角色', Url: '/roles' }
  ];
  mobileQuery: MediaQueryList;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this.mobileQuery.addListener(this.mobileQueryListener);
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.mobileQuery.removeListener(this.mobileQueryListener);
  }

  changeTheme(theme: Theme) {
    this.selectedTheme = theme;
  }
}
