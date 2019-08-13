import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { ThemeService } from '../core/theme/theme.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {
  title = 'Matcha Latte';

  constructor(private themeService: ThemeService) { }

  ngOnInit(): void {
  }
}
