import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CanlendarComponent } from './canlendar.component';

describe('CanlendarComponent', () => {
  let component: CanlendarComponent;
  let fixture: ComponentFixture<CanlendarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CanlendarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CanlendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
