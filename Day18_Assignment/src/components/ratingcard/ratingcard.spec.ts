import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Ratingcard } from './ratingcard';

describe('Ratingcard', () => {
  let component: Ratingcard;
  let fixture: ComponentFixture<Ratingcard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Ratingcard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Ratingcard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
