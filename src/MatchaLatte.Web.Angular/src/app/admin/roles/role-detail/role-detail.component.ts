import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { finalize, tap } from 'rxjs/operators';
import { Guid } from 'src/app/core/guid';
import { Role } from 'src/app/core/role/role';
import { RoleService } from 'src/app/core/role/role.service';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent implements OnInit {
  isLoading = true;
  saveMode = SaveMode.Create;
  role = new Role();

  constructor(
    private roleService: RoleService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    let role$ = this.roleService.getNewRole();
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      role$ = this.roleService.getRole(new Guid(id));
    }
    role$
      .pipe(
        tap(role => this.role = role),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
  }

  save(): void {
    let role$ = this.roleService.createRole(this.role);
    if (this.saveMode === SaveMode.Update) {
      role$ = this.roleService.updateRole(this.role);
    }
    role$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }
}
