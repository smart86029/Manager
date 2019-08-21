import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { AuthService } from '../auth/auth.service';
import { Menu } from '../core/menu/menu';
import { Theme } from '../core/theme/theme.enum';
import { ThemeService } from '../core/theme/theme.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  title = 'Matcha Latte';
  theme: Theme;
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(map(result => result.matches));
  nestedDataSource = new MatTreeNestedDataSource();
  nestedTreeControl = new NestedTreeControl<Menu>(this.getChildren);

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    private authService: AuthService,
    private themeService: ThemeService) { }

  ngOnInit(): void {
    const menus = this.getMenus();
    this.nestedDataSource.data = menus;
    this.nestedTreeControl.dataNodes = menus;
    this.nestedTreeControl.expandAll();
    this.themeService.theme$.subscribe(theme => this.theme = theme);
  }

  getChildren(menu: Menu): Observable<Menu[]> {
    return of(menu.children);
  }

  hasNestedChild(_: number, menu: Menu): boolean {
    return menu.children && menu.children.length > 0;
  }

  signOut(): void {
    this.authService.signOut();
    this.router.navigate(['/']);
  }

  private getMenus(): Menu[] {
    const menus: Menu[] = [
      {
        name: '會員管理', icon: 'person', url: '', children: [
          { name: '使用者', icon: '', url: 'users' },
          { name: '角色', icon: '', url: 'roles' },
          { name: '權限', icon: '', url: 'permissions' }
        ]
      },
    ];
    if (!this.authService.isAuthorized) {
      return menus;
    }
    if (this.authService.hasPermission('特殊權限')) {
      menus.push({
        name: '人力資源管理', icon: 'people', url: '', children: [
          { name: '員工', icon: '', url: 'employees' },
        ]
      });
    }
    menus.push({
      name: '目錄管理', icon: 'store', url: '', children: [
        { name: '店家管理', icon: '', url: 'stores' },
        { name: '團管理', icon: '', url: 'groups' }
      ]
    });
    return menus;
  }
}
