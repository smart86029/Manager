import { Component, OnInit } from '@angular/core';
import { Theme } from 'src/app/shared/theme.enum';
import { OverlayContainer } from '@angular/cdk/overlay';

@Component({
  selector: 'app-guest-index',
  templateUrl: './guest-index.component.html',
  styleUrls: ['./guest-index.component.scss']
})
export class GuestIndexComponent implements OnInit {
  selectedTheme = Theme.Strawberry;
  constructor(
    private overlayContainer: OverlayContainer
  ) { }

  ngOnInit() {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
  }

}
