import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficeslistComponent } from './officeslist.component';

describe('OfficeslistComponent', () => {
  let component: OfficeslistComponent;
  let fixture: ComponentFixture<OfficeslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OfficeslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
