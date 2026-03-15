import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './dash-board.component';

const routes: Routes = [
  { path: '', component: DashBoardComponent, data: { animation: 'dashboard' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)], // <- forChild, NO forRoot
  exports: [RouterModule]
})
export class DashboardRoutingModule { }