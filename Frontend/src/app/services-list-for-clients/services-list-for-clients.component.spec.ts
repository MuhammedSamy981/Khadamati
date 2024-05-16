import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesListForClientsComponent } from './services-list-for-clients.component';

describe('ServicesListForClientsComponent', () => {
  let component: ServicesListForClientsComponent;
  let fixture: ComponentFixture<ServicesListForClientsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServicesListForClientsComponent]
    });
    fixture = TestBed.createComponent(ServicesListForClientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
