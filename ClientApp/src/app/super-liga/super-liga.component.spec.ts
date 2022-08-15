import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuperLigaComponent } from './super-liga.component';

describe('SuperLigaComponent', () => {
  let component: SuperLigaComponent;
  let fixture: ComponentFixture<SuperLigaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuperLigaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuperLigaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
