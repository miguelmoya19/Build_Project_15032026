import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { TaskRoutingModule } from './app-routing-task.module';
import { TasksComponent } from './tasks.component';
import { ComponentsModule } from 'src/app/components/components.module';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [TasksComponent],
  imports: [
    ComponentsModule,
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        TaskRoutingModule,
        MatDialogModule
  ],
  providers: [],
  bootstrap: [],
})
export class AppModuleTask {}
