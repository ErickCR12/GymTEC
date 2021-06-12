import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymConfigComponent } from './gym-config.component';

describe('GymConfigComponent', () => {
  let component: GymConfigComponent;
  let fixture: ComponentFixture<GymConfigComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymConfigComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
