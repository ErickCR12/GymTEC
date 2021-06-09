import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposEquiposComponent } from './tipos-equipos.component';

describe('TiposEquiposComponent', () => {
  let component: TiposEquiposComponent;
  let fixture: ComponentFixture<TiposEquiposComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TiposEquiposComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TiposEquiposComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
