import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { OverlayContainer } from '@angular/cdk/overlay';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav, MatTreeNestedDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { combineLatest, map } from 'rxjs/operators';

import { Menu } from '../../core/menu';
import { MenuService } from '../../core/menu.service';
import { Theme } from '../../theme.enum';

@Component({
  selector: 'app-admin-index',
  templateUrl: './admin-index.component.html',
  styleUrls: ['./admin-index.component.scss']
})
export class AdminIndexComponent implements OnInit {

  title = 'Manager';
  selectedTheme = Theme.Strawberry;
  theme = Theme;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
  nestedDataSource = new MatTreeNestedDataSource();
  nestedTreeControl = new NestedTreeControl<Menu>(this.getChildren);

  @ViewChild('sidenav')
  sidenav: MatSidenav;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private overlayContainer: OverlayContainer,
    private menuService: MenuService,
    private router: Router) { }

  ngOnInit(): void {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
    this.menuService.dataChange.subscribe(data => this.nestedDataSource.data = data);
    this.router.events.pipe(combineLatest(this.isHandset$)).subscribe(x => {
      if (x["1"]) {
        this.sidenav.close();
      }
    });
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
