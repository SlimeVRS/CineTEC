import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtagonistlistComponent } from './protagonistlist.component';

describe('ProtagonistlistComponent', () => {
  let component: ProtagonistlistComponent;
  let fixture: ComponentFixture<ProtagonistlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProtagonistlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtagonistlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
