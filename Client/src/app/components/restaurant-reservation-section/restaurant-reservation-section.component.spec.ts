import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantReservationSectionComponent } from './restaurant-reservation-section.component';

describe('RestaurantReservationSectionComponent', () => {
  let component: RestaurantReservationSectionComponent;
  let fixture: ComponentFixture<RestaurantReservationSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantReservationSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantReservationSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
