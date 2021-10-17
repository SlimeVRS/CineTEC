import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaclienteComponent } from './salacliente.component';

describe('SalaclienteComponent', () => {
  let component: SalaclienteComponent;
  let fixture: ComponentFixture<SalaclienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalaclienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
