import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';
import { ThemeService } from '../core/theme/theme.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent {
  title = 'Matcha Latte';

  constructor(
    public themeService: ThemeService,
    private authService: AuthService,
    private router: Router,
  ) { }

  signOut(): void {
    this.authService.signOut();
    this.router.navigate(['/']);
  }
}
