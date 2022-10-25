import { TestBed } from '@angular/core/testing';

import { AdditionalInformationApiServiceService } from './additional-information-api-service.service';

describe('AdditionalInformationApiServiceService', () => {
  let service: AdditionalInformationApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdditionalInformationApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
