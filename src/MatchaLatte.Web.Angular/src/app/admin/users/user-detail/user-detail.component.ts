import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { finalize, tap } from 'rxjs/operators';
import { Guid } from 'src/app/core/guid';
import { SaveMode } from 'src/app/core/save-mode.enum';
import { User } from 'src/app/core/user/user';
import { UserService } from 'src/app/core/user/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {
  isLoading = true;
  saveMode = SaveMode.Create;
  user = new User();

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    let user$ = this.userService.getNewUser();
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      user$ = this.userService.getUser(new Guid(id));
    }
    user$
      .pipe(
        tap(user => this.user = user),
        finalize(() => this.isLoading = false))
      .subscribe();
  }

  save(): void {
    let user$ = this.userService.createUser(this.user);
    if (this.saveMode === SaveMode.Update) {
      user$ = this.userService.updateUser(this.user);
    }
    user$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }
}
