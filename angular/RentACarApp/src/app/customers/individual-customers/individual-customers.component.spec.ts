import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualCustomersComponent } from './individual-customers.component';

describe('IndividualCustomersComponent', () => {
  let component: IndividualCustomersComponent;
  let fixture: ComponentFixture<IndividualCustomersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndividualCustomersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualCustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
