import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CopySemComponent } from './copy-sem.component';

describe('CopySemComponent', () => {
  let component: CopySemComponent;
  let fixture: ComponentFixture<CopySemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CopySemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CopySemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
