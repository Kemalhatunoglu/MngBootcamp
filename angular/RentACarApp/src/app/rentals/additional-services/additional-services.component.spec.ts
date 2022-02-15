import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionalServicesComponent } from './additional-services.component';

describe('AdditionalServicesComponent', () => {
  let component: AdditionalServicesComponent;
  let fixture: ComponentFixture<AdditionalServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionalServicesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditionalServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
