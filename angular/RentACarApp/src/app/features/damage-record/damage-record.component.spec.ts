import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DamageRecordComponent } from './damage-record.component';

describe('DamageRecordComponent', () => {
  let component: DamageRecordComponent;
  let fixture: ComponentFixture<DamageRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DamageRecordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DamageRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
