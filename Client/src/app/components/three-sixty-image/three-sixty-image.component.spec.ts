import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreeSixtyImageComponent } from './three-sixty-image.component';

describe('ThreeSixtyImageComponent', () => {
  let component: ThreeSixtyImageComponent;
  let fixture: ComponentFixture<ThreeSixtyImageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThreeSixtyImageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ThreeSixtyImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
