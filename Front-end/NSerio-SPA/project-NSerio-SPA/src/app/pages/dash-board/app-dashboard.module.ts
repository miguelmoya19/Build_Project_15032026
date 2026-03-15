import { NgModule } from '@angular/core';
import { DashBoardComponent } from './dash-board.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { DashboardRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatChipsModule } from '@angular/material/chips';
import { HttpClientModule } from '@angular/common/http';
import { CreateTaskDialogComponent } from './modals/create-task-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { NgChartsModule } from 'ng2-charts';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ComponentsModule } from 'src/app/components/components.module';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    DashBoardComponent,
    CreateTaskDialogComponent,
  ],
  imports: [
    MatExpansionModule,
    DashboardRoutingModule,
    CommonModule,
    HttpClientModule,
    MatCardModule,
    MatChipsModule,
    MatProgressBarModule,
    MatDialogModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgChartsModule,
    FormsModule,
    ReactiveFormsModule,
    ComponentsModule,
    MatIconModule
],
  providers: [],
  bootstrap: [],
})
export class AppModuleDashBoard {}
