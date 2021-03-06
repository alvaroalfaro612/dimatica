import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DutyListComponent } from './dutylist.component';

describe('DutyListComponent', () => {
  let component: DutyListComponent;
  let fixture: ComponentFixture<DutyListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DutyListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DutyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
