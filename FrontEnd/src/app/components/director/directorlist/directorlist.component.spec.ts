import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirectorlistComponent } from './directorlist.component';

describe('DirectorlistComponent', () => {
  let component: DirectorlistComponent;
  let fixture: ComponentFixture<DirectorlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DirectorlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DirectorlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
