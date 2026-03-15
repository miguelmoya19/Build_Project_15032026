import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./pages/dash-board/app-dashboard.module').then(m => m.AppModuleDashBoard)
  },
  {
    path: 'developers',
    loadChildren: () =>
      import('./pages/developers/app-developers.module').then(m => m.AppModuleDevelopers)
  },
  {
    path: 'tasks',
    loadChildren: () =>
      import('./pages/task/app-task.module').then(m => m.AppModuleTask)
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('./pages/projects/app-projects.module').then(m => m.AppModuleProjects)
  },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full' // ruta por defecto
  },
//   {
//     path: '**',
//     redirectTo: 'dashboard' // wildcard
//   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}