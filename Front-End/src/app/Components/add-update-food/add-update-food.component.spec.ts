import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateFoodComponent } from './add-update-food.component';

describe('AddUpdateFoodComponent', () => {
  let component: AddUpdateFoodComponent;
  let fixture: ComponentFixture<AddUpdateFoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateFoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateFoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
