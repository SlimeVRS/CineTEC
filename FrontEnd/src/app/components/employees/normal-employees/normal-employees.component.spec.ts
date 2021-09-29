import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NormalEmployeesComponent } from './normal-employees.component';

describe('NormalEmployeesComponent', () => {
  let component: NormalEmployeesComponent;
  let fixture: ComponentFixture<NormalEmployeesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NormalEmployeesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NormalEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
