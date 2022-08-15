import { TestBed } from '@angular/core/testing';

import { SuperLigaService } from './super-liga.service';

describe('SuperLigaService', () => {
  let service: SuperLigaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuperLigaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
