import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableTratamientosComponent } from './table-tratamientos.component';

describe('TableTratamientosComponent', () => {
  let component: TableTratamientosComponent;
  let fixture: ComponentFixture<TableTratamientosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableTratamientosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableTratamientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
