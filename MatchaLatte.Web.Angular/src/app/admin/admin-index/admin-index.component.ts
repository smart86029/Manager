import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { OverlayContainer } from '@angular/cdk/overlay';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from 'src/app/auth/auth.service';
import { Menu } from 'src/app/menu/menu';
import { MenuService } from 'src/app/menu/menu.service';
import { Theme } from 'src/app/shared/theme.enum';

@Component({
  selector: 'app-admin-index',
  templateUrl: './admin-index.component.html',
  styleUrls: ['./admin-index.component.scss'],
})
export class AdminIndexComponent implements OnInit {
  title = 'Matcha Latte';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(map(result => result.matches));
  nestedDataSource = new MatTreeNestedDataSource();
  nestedTreeControl = new NestedTreeControl<Menu>(this.getChildren);

  constructor(private breakpointObserver: BreakpointObserver,
    private overlayContainer: OverlayContainer,
    private router: Router,
    private menuService: MenuService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
    this.menuService.menus$.subscribe(data => this.nestedDataSource.data = data);
  }

  changeTheme(theme: Theme): void {
    this.overlayContainer.getContainerElement().classList.remove(this.selectedTheme);
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.selectedTheme = theme;
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
