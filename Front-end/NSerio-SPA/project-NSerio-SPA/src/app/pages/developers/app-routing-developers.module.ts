import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { DashBoardComponent } from './dash-board.component';
import { DevelopersComponent } from './developers.component';

const routes: Routes = [
  { path: '', component: DevelopersComponent, data: { animation: 'developers' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)], // <- forChild, NO forRoot
  exports: [RouterModule]
})
export class DevelopersRoutingModule { }