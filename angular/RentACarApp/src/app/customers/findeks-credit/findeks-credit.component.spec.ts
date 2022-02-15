import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindeksCreditComponent } from './findeks-credit.component';

describe('FindeksCreditComponent', () => {
  let component: FindeksCreditComponent;
  let fixture: ComponentFixture<FindeksCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindeksCreditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindeksCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
