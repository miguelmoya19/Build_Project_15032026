import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RowHighlightPipe } from '../pipe/row-highlight.pipe';

@NgModule({
  declarations: [
    GenericTableComponent,
    RowHighlightPipe
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
     MatFormFieldModule,
    MatInputModule,
  ],
  exports: [
    GenericTableComponent
  ]
})
export class ComponentsModule { }
