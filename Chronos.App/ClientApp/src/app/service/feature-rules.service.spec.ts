import { TestBed } from '@angular/core/testing';

import { FeatureRulesService } from './feature-rules.service';

describe('FeatureRulesService', () => {
  let service: FeatureRulesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FeatureRulesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
