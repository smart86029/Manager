import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { AuthService } from '../auth/auth.service';
import { Menu } from '../core/menu/menu';
import { MenuService } from '../core/menu/menu.service';
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
    private menuService: MenuService,
    private authService: AuthService,
    private themeService: ThemeService) { }

  ngOnInit(): void {
    this.menuService.menus$.subscribe(data => this.nestedDataSource.data = data);
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
}
