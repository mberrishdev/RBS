import { TestBed } from '@angular/core/testing';

import { TersmAndConditionsService } from './tersm-and-conditions.service';

describe('TersmAndConditionsService', () => {
  let service: TersmAndConditionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TersmAndConditionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
