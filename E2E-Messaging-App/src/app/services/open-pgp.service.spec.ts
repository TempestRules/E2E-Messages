import { TestBed } from '@angular/core/testing';

import { OpenPGPService } from './open-pgp.service';

describe('OpenPGPService', () => {
  let service: OpenPGPService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenPGPService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
