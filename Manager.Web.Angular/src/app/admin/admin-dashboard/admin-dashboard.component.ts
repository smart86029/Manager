import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';

import { Menu } from '../../core/menu';
import { Theme } from '../../theme.enum';
import { OverlayContainer } from '@angular/cdk/overlay';
import { MenuService } from '../../core/menu.service';
import { MatTreeNestedDataSource } from '@angular/material';
import { NestedTreeControl } from '@angular/cdk/tree';
import { of, Observable } from 'rxjs';

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
    {
      name: '會員管理', url: '/', children: [
        { name: '使用者', url: '/users', children: null },
        { name: '角色', url: '/roles', children: null }
      ]
    }
  ];
  showSidenav: MediaQueryList;
  nestedDataSource = new MatTreeNestedDataSource();
  nestedTreeControl = new NestedTreeControl<Menu>(this.getChildren);

  private listener: () => void;

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private media: MediaMatcher,
    private overlayContainer: OverlayContainer,
    private menuService: MenuService) { }

  ngOnInit(): void {
    this.listener = () => this.changeDetectorRef.detectChanges();
    this.showSidenav = this.media.matchMedia('(min-width: 1600px)');
    this.showSidenav.addListener(this.listener);
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
    this.menuService.dataChange.subscribe(data => this.nestedDataSource.data = data);
  }

  ngOnDestroy(): void {
    this.showSidenav.removeListener(this.listener);
  }

  changeTheme(theme: Theme): void {
    this.overlayContainer.getContainerElement().classList.remove(this.selectedTheme);
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.selectedTheme = theme;
  }

  getChildren(menu: Menu): Observable<Menu[]> {
    return of(menu.children);
  }

  hasNestedChild(_: number, menu: Menu) {
    return menu.children && menu.children.length > 0;
  }
}
