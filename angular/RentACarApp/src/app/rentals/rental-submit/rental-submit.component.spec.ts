import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentalSubmitComponent } from './rental-submit.component';

describe('RentalSubmitComponent', () => {
  let component: RentalSubmitComponent;
  let fixture: ComponentFixture<RentalSubmitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RentalSubmitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RentalSubmitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
