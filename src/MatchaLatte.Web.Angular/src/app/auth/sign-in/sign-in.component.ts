import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthService } from '../auth.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  userName: string;
  password: string;

  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void { }

  signIn(): void {
    this.authService
      .signIn(this.userName, this.password)
      .pipe(
        tap(() => {
          const redirect = this.route.snapshot.queryParams.returnUrl || '/';
          this.router.navigate([redirect]);
        }))
      .subscribe();
  }

  signOut(): void {
    this.authService.signOut();
  }
}
