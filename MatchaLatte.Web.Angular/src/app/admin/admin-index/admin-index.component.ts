import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Menu } from 'src/app/menu/menu';
import { MenuService } from 'src/app/menu/menu.service';
import { Theme } from 'src/app/shared/theme.enum';
import { OverlayContainer } from '@angular/cdk/overlay';

@Component({
  selector: 'app-admin-index',
  templateUrl: './admin-index.component.html',
  styleUrls: ['./admin-index.component.scss'],
})
export class AdminIndexComponent {
  title = 'Matcha Latte';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
  nestedDataSource = new MatTreeNestedDataSource();
  nestedTreeControl = new NestedTreeControl<Menu>(this.getChildren);

  constructor(private breakpointObserver: BreakpointObserver,
    private overlayContainer: OverlayContainer,
    private menuService: MenuService) { }

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

  hasNestedChild(_: number, menu: Menu) {
    return menu.children && menu.children.length > 0;
  }
}
