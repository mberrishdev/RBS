import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantMenuSectionComponent } from './restaurant-menu-section.component';

describe('RestaurantMenuSectionComponent', () => {
  let component: RestaurantMenuSectionComponent;
  let fixture: ComponentFixture<RestaurantMenuSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantMenuSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantMenuSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
