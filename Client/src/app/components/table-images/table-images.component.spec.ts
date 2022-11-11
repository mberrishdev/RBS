import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableImagesComponent } from './table-images.component';

describe('TableImagesComponent', () => {
  let component: TableImagesComponent;
  let fixture: ComponentFixture<TableImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableImagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
