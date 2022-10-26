import { TestBed } from '@angular/core/testing';

import { RestaruantService } from './restaruant.service';

describe('RestaruantService', () => {
  let service: RestaruantService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestaruantService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
