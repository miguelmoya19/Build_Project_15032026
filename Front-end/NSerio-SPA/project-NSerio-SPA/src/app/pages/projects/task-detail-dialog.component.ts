import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITask } from '../../interfaces/ITask';

@Component({
  selector: 'task-detail-dialog',
  template: `
    <h2 mat-dialog-title>{{ data.title }}</h2>
    <mat-dialog-content>
      <p><strong>Asignado a:</strong> {{ data.assignedTo }}</p>
      <p><strong>Estado:</strong> {{ data.status }}</p>
      <p><strong>Prioridad:</strong> {{ data.priority }}</p>
      <p><strong>Complejidad estimada:</strong> {{ data.estimatedComplexity }}</p>
      <p><strong>Fecha de creación:</strong> {{ data.creationDate | date }}</p>
      <p><strong>Fecha de vencimiento:</strong> {{ data.dueDate | date }}</p>
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button mat-dialog-close>Cerrar</button>
    </mat-dialog-actions>
  `
})
export class TaskDetailDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: ITask) {}
}