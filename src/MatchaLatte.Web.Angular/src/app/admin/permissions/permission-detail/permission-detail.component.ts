import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { finalize, tap } from 'rxjs/operators';
import { Guid } from 'src/app/core/guid';
import { Permission } from 'src/app/core/permission/permission';
import { PermissionService } from 'src/app/core/permission/permission.service';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Component({
  selector: 'app-permission-detail',
  templateUrl: './permission-detail.component.html',
  styleUrls: ['./permission-detail.component.scss']
})
export class PermissionDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  permission = new Permission();

  constructor(private permissionService: PermissionService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.isLoading = true;
      this.saveMode = SaveMode.Update;
      this.permissionService
        .getPermission(new Guid(id))
        .pipe(
          tap(permission => this.permission = permission),
          finalize(() => this.isLoading = false)
        )
        .subscribe();
    }
  }

  save(): void {
    let permission$ = this.permissionService.createPermission(this.permission);
    if (this.saveMode === SaveMode.Update) {
      permission$ = this.permissionService.updatePermission(this.permission);
    }
    permission$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }
}
