import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuroraDicesComponent } from './aurora-dices.component';

describe('AuroraDicesComponent', () => {
  let component: AuroraDicesComponent;
  let fixture: ComponentFixture<AuroraDicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuroraDicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuroraDicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
