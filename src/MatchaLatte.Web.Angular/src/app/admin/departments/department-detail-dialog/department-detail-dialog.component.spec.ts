import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentDetailDialogComponent } from './department-detail-dialog.component';

describe('DepartmentDetailDialogComponent', () => {
  let component: DepartmentDetailDialogComponent;
  let fixture: ComponentFixture<DepartmentDetailDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentDetailDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentDetailDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
