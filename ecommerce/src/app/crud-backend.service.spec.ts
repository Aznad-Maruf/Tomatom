import { TestBed } from '@angular/core/testing';

import { CrudBackendService } from './crud-backend.service';

describe('CrudBackendService', () => {
  let service: CrudBackendService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrudBackendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
