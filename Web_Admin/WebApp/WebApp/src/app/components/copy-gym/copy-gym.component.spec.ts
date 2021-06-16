import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CopyGymComponent } from './copy-gym.component';

describe('CopyGymComponent', () => {
  let component: CopyGymComponent;
  let fixture: ComponentFixture<CopyGymComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CopyGymComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CopyGymComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
