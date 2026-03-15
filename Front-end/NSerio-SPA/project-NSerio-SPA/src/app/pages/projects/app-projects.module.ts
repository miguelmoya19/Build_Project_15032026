import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { ProjectsRoutingModule } from './app-routing-projects.module';
import { ProjectsComponent } from './projects.component';
import { TaskDetailDialogComponent } from './task-detail-dialog.component';
import { ComponentsModule } from 'src/app/components/components.module';

@NgModule({
  declarations: [ProjectsComponent, TaskDetailDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    ProjectsRoutingModule,
    ComponentsModule
  ]
})
export class AppModuleProjects { }