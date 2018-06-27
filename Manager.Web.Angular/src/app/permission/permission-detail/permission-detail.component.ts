import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Permission } from '../permission';
import { PermissionService } from '../permission.service';

@Component({
  selector: 'app-permission-detail',
  templateUrl: './permission-detail.component.html',
  styleUrls: ['./permission-detail.component.scss']
})
export class PermissionDetailComponent implements OnInit {
  saveMode = SaveMode.Create;
  permission = new Permission();

  constructor(private permissionService: PermissionService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.permissionService.getPermission(id)
        .subscribe(permission => this.permission = permission);
    } else {
      this.permission = new Permission();
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.permissionService.createPermission(this.permission)
      .subscribe(permission => this.location.back());
  }

  private update(): void {
    this.permissionService.updatePermission(this.permission)
      .subscribe(permission => this.location.back());
  }
}