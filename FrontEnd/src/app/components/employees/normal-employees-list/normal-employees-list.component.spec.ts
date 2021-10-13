import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NormalEmployeesListComponent } from './normal-employees-list.component';

describe('NormalEmployeesListComponent', () => {
  let component: NormalEmployeesListComponent;
  let fixture: ComponentFixture<NormalEmployeesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NormalEmployeesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NormalEmployeesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
