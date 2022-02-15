import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransmissionsComponent } from './transmissions.component';

describe('TransmissionsComponent', () => {
  let component: TransmissionsComponent;
  let fixture: ComponentFixture<TransmissionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransmissionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransmissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
