import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Role } from '../role';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent implements OnInit {
  saveMode = SaveMode.Create;
  role = new Role();

  constructor(private roleService: RoleService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.roleService.getRole(id)
        .subscribe(role => this.role = role);
    } else {
      this.role = new Role();
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

  private create(): void {
    this.roleService.createRole(this.role)
      .subscribe(role => this.location.back());
  }

  private update(): void {
    this.roleService.updateRole(this.role)
      .subscribe(role => this.location.back());
  }
}
