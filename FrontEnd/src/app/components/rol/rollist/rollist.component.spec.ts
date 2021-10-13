import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RollistComponent } from './rollist.component';

describe('RollistComponent', () => {
  let component: RollistComponent;
  let fixture: ComponentFixture<RollistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RollistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RollistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
