import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantBookingComponent } from './restaurant-booking.component';

describe('RestaurantBookingComponent', () => {
  let component: RestaurantBookingComponent;
  let fixture: ComponentFixture<RestaurantBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantBookingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
