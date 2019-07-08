import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { Theme } from 'src/app/shared/theme.enum';

@Component({
  selector: 'app-member-index',
  templateUrl: './member-index.component.html',
  styleUrls: ['./member-index.component.scss']
})
export class MemberIndexComponent implements OnInit {
  selectedTheme = Theme.Strawberry;

  constructor(private overlayContainer: OverlayContainer) { }

  ngOnInit(): void {
    this.overlayContainer.getContainerElement().classList.add(this.selectedTheme);
  }
}
