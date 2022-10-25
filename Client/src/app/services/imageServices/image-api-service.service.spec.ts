import { TestBed } from '@angular/core/testing';

import { ImageApiServiceService } from './image-api-service.service';

describe('ImageApiServiceService', () => {
  let service: ImageApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
