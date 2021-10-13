import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatReservComponent } from './seat-reserv.component';

describe('SeatReservComponent', () => {
  let component: SeatReservComponent;
  let fixture: ComponentFixture<SeatReservComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatReservComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatReservComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
