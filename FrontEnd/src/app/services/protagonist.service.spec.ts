import { TestBed } from '@angular/core/testing';

import { ProtagonistService } from './protagonist.service';

describe('ProtagonistService', () => {
  let service: ProtagonistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProtagonistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
