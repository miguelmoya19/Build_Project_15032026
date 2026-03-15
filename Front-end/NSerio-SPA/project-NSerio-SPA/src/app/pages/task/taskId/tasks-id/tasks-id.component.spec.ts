import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasksIdComponent } from './tasks-id.component';

describe('TasksIdComponent', () => {
  let component: TasksIdComponent;
  let fixture: ComponentFixture<TasksIdComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TasksIdComponent]
    });
    fixture = TestBed.createComponent(TasksIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
