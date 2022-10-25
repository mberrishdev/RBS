import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantAdditionalInformationComponent } from './restaurant-additional-information.component';

describe('RestaurantAdditionalInformationComponent', () => {
  let component: RestaurantAdditionalInformationComponent;
  let fixture: ComponentFixture<RestaurantAdditionalInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantAdditionalInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantAdditionalInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
