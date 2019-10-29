import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Department } from 'src/app/core/department/department';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Component({
  selector: 'app-department-detail-dialog',
  templateUrl: './department-detail-dialog.component.html',
  styleUrls: ['./department-detail-dialog.component.scss']
})
export class DepartmentDetailDialogComponent implements OnInit {
  saveMode = SaveMode.Create;
  department = new Department();

  constructor(@Inject(MAT_DIALOG_DATA) public parent: Department) {
  }

  ngOnInit(): void {
    this.department.parentId = this.parent.id;
  }
}
