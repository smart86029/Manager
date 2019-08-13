import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { Theme } from 'src/app/core/theme/theme.enum';
import { ThemeService } from 'src/app/core/theme/theme.service';

@Component({
  selector: 'app-theme-picker',
  templateUrl: './theme-picker.component.html',
  styleUrls: ['./theme-picker.component.scss']
})
export class ThemePickerComponent implements OnInit {
  selectedTheme = Theme.Strawberry;
  theme = Theme;

  constructor(private themeService: ThemeService, private overlayContainer: OverlayContainer) { }

  ngOnInit() {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
    this.themeService.theme$.subscribe({
      next: theme => this.selectedTheme = theme
    });
  }

  changeTheme(theme: Theme): void {
    this.overlayContainer.getContainerElement().classList.remove(this.selectedTheme);
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.themeService.theme$.next(theme);
  }
}
