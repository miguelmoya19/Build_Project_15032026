import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DevelopersComponent } from './developers.component';
import { DevelopersRoutingModule } from './app-routing-developers.module';
import { ComponentsModule } from 'src/app/components/components.module';

@NgModule({
  declarations: [DevelopersComponent],
  imports: [
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        MatPaginatorModule,
        DevelopersRoutingModule,
        ComponentsModule
  ],
  providers: [],
  bootstrap: [],
})
export class AppModuleDevelopers {}
