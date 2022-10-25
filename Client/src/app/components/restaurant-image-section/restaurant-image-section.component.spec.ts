import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantImageSectionComponent } from './restaurant-image-section.component';

describe('RestaurantImageSectionComponent', () => {
  let component: RestaurantImageSectionComponent;
  let fixture: ComponentFixture<RestaurantImageSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantImageSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantImageSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
