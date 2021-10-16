import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtagonistComponent } from './protagonist.component';

describe('ProtagonistComponent', () => {
  let component: ProtagonistComponent;
  let fixture: ComponentFixture<ProtagonistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProtagonistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtagonistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
