import { TestBed } from '@angular/core/testing';

import { NserioApiService } from './nserio-api.service';

describe('NserioApiService', () => {
  let service: NserioApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NserioApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
