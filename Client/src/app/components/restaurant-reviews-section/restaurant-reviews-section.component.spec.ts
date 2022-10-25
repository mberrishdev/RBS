import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantReviewsSectionComponent } from './restaurant-reviews-section.component';

describe('RestaurantReviewsSectionComponent', () => {
  let component: RestaurantReviewsSectionComponent;
  let fixture: ComponentFixture<RestaurantReviewsSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantReviewsSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantReviewsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
