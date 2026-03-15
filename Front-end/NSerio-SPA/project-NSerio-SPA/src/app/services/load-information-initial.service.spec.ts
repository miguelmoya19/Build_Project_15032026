import { TestBed } from '@angular/core/testing';

import { LoadInformationInitialService } from './load-information-initial.service';

describe('LoadInformationInitialService', () => {
  let service: LoadInformationInitialService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoadInformationInitialService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
