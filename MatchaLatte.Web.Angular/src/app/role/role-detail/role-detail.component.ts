import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/shared/guid';
import { SaveMode } from 'src/app/shared/save-mode/save-mode.enum';

import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  role = new Role();

  constructor(private roleService: RoleService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.roleService
        .getRole(new Guid(id))
        .subscribe({
          next: role => this.role = role,
          complete: () => this.isLoading = false
        });
    } else {
      this.roleService
        .getNewRole()
        .subscribe({
          next: role => this.role = role,
          complete: () => this.isLoading = false
        });
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
    this.roleService
      .createRole(this.role)
      .subscribe(role => this.location.back());
  }

  private update(): void {
    this.roleService
      .updateRole(this.role)
      .subscribe(role => this.location.back());
  }
}
