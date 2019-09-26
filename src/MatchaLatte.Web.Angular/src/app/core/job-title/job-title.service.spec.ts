import { TestBed } from '@angular/core/testing';

import { JobTitleService } from './job-title.service';

describe('JobTitleService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JobTitleService = TestBed.get(JobTitleService);
    expect(service).toBeTruthy();
  });
});
