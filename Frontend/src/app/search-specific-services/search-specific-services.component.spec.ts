import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchSpecificServicesComponent } from './search-specific-services.component';

describe('SearchSpecificServicesComponent', () => {
  let component: SearchSpecificServicesComponent;
  let fixture: ComponentFixture<SearchSpecificServicesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchSpecificServicesComponent]
    });
    fixture = TestBed.createComponent(SearchSpecificServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
