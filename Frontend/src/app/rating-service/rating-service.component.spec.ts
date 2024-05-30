import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingServiceComponent } from './rating-service.component';

describe('RatingServiceComponent', () => {
  let component: RatingServiceComponent;
  let fixture: ComponentFixture<RatingServiceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RatingServiceComponent]
    });
    fixture = TestBed.createComponent(RatingServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
