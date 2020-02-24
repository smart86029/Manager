import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { EMPTY } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { Department } from 'src/app/core/department/department';
import { DepartmentService } from 'src/app/core/department/department.service';
import { Guid } from 'src/app/core/guid';
import { ComfirmDialogComponent } from 'src/app/shared/components/comfirm-dialog/comfirm-dialog.component';

import { DepartmentDetailDialogComponent } from '../department-detail-dialog/department-detail-dialog.component';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.scss']
})
export class DepartmentListComponent implements OnInit {
  dataSource = new MatTreeNestedDataSource<Department>();
  treeControl = new NestedTreeControl<Department>(department => department.children);

  constructor(
    private departmentService: DepartmentService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.departmentService
      .getDepartments()
      .pipe(
        map(departments => {
          const treeMap = new Map<Guid, Department>();
          const result: Department[] = [];
          departments.forEach(department => treeMap.set(department.id, department));
          departments.forEach(department => {
            if (!!department.parentId) {
              treeMap.get(department.parentId).children.push(department);
            } else {
              result.push(department);
            }
          });
          return result;
        }),
        tap(departments => {
          this.dataSource.data = departments;
          this.treeControl.dataNodes = departments;
          this.treeControl.expandAll();
        })
      )
      .subscribe();
  }

  hasChild(_: number, department: Department): boolean {
    return !!department.children && department.children.length > 0;
  }

  createDepartment(parent: Department): void {
    this.dialog
      .open(DepartmentDetailDialogComponent, { data: parent })
      .afterClosed()
      .pipe(
        switchMap(data => !!data ?
          this.departmentService
            .createDepartment(data)
            .pipe(
              tap(() => window.location.reload())) :
          EMPTY))
      .subscribe();
  }

  deleteDepartment(department: Department): void {
    this.dialog
      .open(ComfirmDialogComponent, { data: `是否刪除部門 (${department.name})?` })
      .afterClosed()
      .pipe(
        switchMap(data => !!data ?
          this.departmentService
            .deleteDepartment(department)
            .pipe(
              tap(() => window.location.reload())) :
          EMPTY)
      )
      .subscribe();
  }
}
