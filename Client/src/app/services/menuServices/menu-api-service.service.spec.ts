import { TestBed } from '@angular/core/testing';

import { MenuApiServiceService } from './menu-api-service.service';

describe('MenuApiServiceService', () => {
  let service: MenuApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MenuApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
