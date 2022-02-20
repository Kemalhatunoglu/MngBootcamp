import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarCarouselComponent } from './car-carousel.component';

describe('CarCarouselComponent', () => {
  let component: CarCarouselComponent;
  let fixture: ComponentFixture<CarCarouselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarCarouselComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
