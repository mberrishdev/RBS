import { TestBed } from '@angular/core/testing';

import { ReviewApiServiceService } from './review-api-service.service';

describe('ReviewApiServiceService', () => {
  let service: ReviewApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReviewApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
