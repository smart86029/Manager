import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';
import { ThemeService } from '../core/theme/theme.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {
  title = 'Matcha Latte';

  constructor(
    public themeService: ThemeService,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
  }

  signOut(): void {
    this.authService.signOut();
    this.router.navigate(['/']);
  }
}
