import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';

import { Theme } from '../shared/theme.enum';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {
  selectedTheme = Theme.Strawberry;

  constructor(private overlayContainer: OverlayContainer) { }

  ngOnInit(): void {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
  }
}
