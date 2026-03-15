import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TasksComponent } from './tasks.component';
import { TasksIdComponent } from './taskId/tasks-id/tasks-id.component';

const routes: Routes = [
  { path: '', component: TasksComponent, data: { animation: 'tasks' } },
  { path: 'informationTask/:id', component: TasksIdComponent, data: { animation: 'tasks' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)], 
  exports: [RouterModule]
})
export class TaskRoutingModule { }