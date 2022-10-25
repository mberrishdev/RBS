import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRestaurantCarculerComponent } from './top-restaurant-carculer.component';

describe('TopRestaurantCarculerComponent', () => {
  let component: TopRestaurantCarculerComponent;
  let fixture: ComponentFixture<TopRestaurantCarculerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopRestaurantCarculerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopRestaurantCarculerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
