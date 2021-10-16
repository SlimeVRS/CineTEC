import { TestBed } from '@angular/core/testing';

import { SalaclienteService } from './salacliente.service';

describe('SalaclienteService', () => {
  let service: SalaclienteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaclienteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
