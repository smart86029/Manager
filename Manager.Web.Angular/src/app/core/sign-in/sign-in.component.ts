import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { SharedModule} from '../../shared/shared.module';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  userName: string ;
  password: string;

  constructor(public authService: AuthService, public router: Router) {
  }

  ngOnInit() {
  }

  signIn() {
    this.authService.signIn(this.userName, this.password).subscribe(() => {
      if (this.authService.isAuthorized()) {
        const redirect = this.authService.redirectUrl ? this.authService.redirectUrl : '/';
        this.router.navigate([redirect]);
      }
    });
  }

  signOut() {
    this.authService.signOut();
  }
}
