import { formatCurrency } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
// import { MatDialogRef } from '@angular/material/dialog';
import { ChangeInformationService } from 'src/app/services/change-information.service';
import { MessageService } from 'src/app/services/message-service';
import { NserioApiService } from 'src/app/services/nserio-api.service';
import Swal from 'sweetalert2';
import { IAllTasks, IAllTasksSpanish } from '../../task/interfaces/IAllTasks';
import { concat, concatMap, map, Observable, Subscription, switchMap, tap } from 'rxjs';
import { Developer, PriorityStatus, ProjectStatus, ResponseModelGenericStatus, TaskStatus } from 'src/app/interfaces/ICodeGenericModel';
import { responseModel } from 'src/app/Shared/responseModel';
import { LoadInformationInitialService } from 'src/app/services/load-information-initial.service';

@Component({
  selector: 'app-create-task-dialog',
  templateUrl: './create-task-dialog.component.html',
  styleUrls: ['./create-task-dialog.component.css'],
})
export class CreateTaskDialogComponent implements OnInit, OnDestroy {
  public formTask!: FormGroup;
  public showErrors = false;
  private suscription$: Subscription | undefined;
  public projectInformation: ProjectStatus[] = [];
  public tasksInformation: TaskStatus[] = [];
  public devInformation: Developer[] = [];
  public priorityInformation: PriorityStatus[] = [];

  constructor(
    public readonly dialogRef: MatDialog,
    private readonly api: NserioApiService,
    private readonly formB: FormBuilder,
    private readonly shared: ChangeInformationService<IAllTasksSpanish>,
    private readonly swal: MessageService,
    private readonly loadInfo:LoadInformationInitialService
  ) {
    this.formTask = this.formB.group({
      projectId: [-1],
      title: [null, Validators.required],
      description: [''],
      assigneeId: [-1],
      status: [null, Validators.required],
      priority: [null, Validators.required],
      estimatedComplexity: [null, Validators.required],
      dueDate: [''],
    });
  }

  ngOnInit(): void {

  

    this.suscription$ = this.shared
      .getterSubject()
      .pipe(concatMap((data) => this.loadAsync().pipe(map(() => data))))
      .subscribe({
        next: (res) => {
          console.log(res);

          this.formTask.patchValue({
            projectId: res.Proyecto,
            title: res.Título,
            description: res.Descripción,
            assigneeId: res['Asignado a'],
            status: res.Estado,
            priority: res.Prioridad,
            estimatedComplexity: res['Complejidad estimada'],
            dueDate: res['Fecha de vencimiento'].split('T')[0],
          });
         
          console.log(res);

        },
        error: (err) => {
          this.swal.error(
            'Error',
            'No se pudo obtener la información adecuadamente.',
          );
        },
      });
  }

  ngOnDestroy(): void {
    if (this.suscription$) this.suscription$.unsubscribe();
  }

  public loadAsync()  {
   return  this.loadInfo.Initialnformation()
      .pipe(
        tap((res: responseModel<ResponseModelGenericStatus>) => {
          const { priority, developers, projects, tasks } = res.data;
          this.devInformation = developers;
          this.tasksInformation = tasks;
          this.projectInformation = projects;
          this.priorityInformation = priority;
        }),
      )
  }

  onCancel(): void {
    this.showErrors = false;
    this.dialogRef.closeAll();
  }

  public saveTasks(): void {
    if (this.formTask.valid) {
      this.api.createAppNSerio(`Task/tasks`, this.formTask.value).subscribe({
        next: (res) => {
          Swal.fire({
            toast: true,
            position: 'top-end',
            icon: 'success',
            title: 'Guardado correctamente',
            text: res?.message,
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
          });
        },
        error: (err) => {
          console.log(err);
          Swal.fire({
            toast: true,
            position: 'top-end',
            icon: 'error',
            title: 'Error al guardar la tarea',
            text: err?.error?.message,
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            iconColor: '#dc3545',
          });
        },
      });
    } else {
      this.showErrors = true;
      this.formTask.markAllAsTouched();
    }
  }


}