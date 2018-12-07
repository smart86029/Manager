import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GuestGalleryComponent } from './guest-gallery.component';

describe('GuestGalleryComponent', () => {
  let component: GuestGalleryComponent;
  let fixture: ComponentFixture<GuestGalleryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GuestGalleryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GuestGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
