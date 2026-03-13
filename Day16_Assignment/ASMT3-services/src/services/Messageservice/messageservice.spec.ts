import { TestBed } from '@angular/core/testing';

import { Messageservice } from '../Messageservice/messageservice';

describe('Messageservice', () => {
  let service: Messageservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Messageservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
