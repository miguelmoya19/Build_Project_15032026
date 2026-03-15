import { formatCurrency } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
// import { MatDialogRef } from '@angular/material/dialog';
import { ChangeInformationService } from 'src/app/services/change-information.service';
import { MessageService } from 'src/app/services/message-service';
import { NserioApiService } from 'src/app/services/nserio-api.service';
import Swal from 'sweetalert2';
import { IAllTasks, IAllTasksSpanish } from '../../../interfaces/IAllTasks';
import { concat, concatMap, map, Observable, Subscription, switchMap, tap } from 'rxjs';
import { Developer, PriorityStatus, ProjectStatus, ResponseModelGenericStatus, TaskStatus } from 'src/app/interfaces/ICodeGenericModel';
import { responseModel } from 'src/app/Shared/responseModel';
import { LoadInformationInitialService } from 'src/app/services/load-information-initial.service';
import { Router } from '@angular/router';

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
    private readonly loadInfo:LoadInformationInitialService,
    private readonly router:Router,

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
        },
        error: (err) => {
          this.swal.error(
            'Error',
            'No se pudo obtener la información adecuadamente.',
          );
        },
      });

      this.getTaskId();
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

  public handleTaskAction(): void {
    if(!this.IsBtnClose){
        this.updateTasks();
    }else{
      this.saveTasks();
    }
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

  public updateTasks(): void {

    const {status, priority, estimatedComplexity } = this.formTask.value;

    const model = {
      status: status,
      priority: priority,
      estimatedComplexity: estimatedComplexity,
    }

    this.api.updateAppNSerio(`Task/${this.taskIdUp}/status`, model).subscribe({
      next: (res) => {
      this.swal.success('Se actualizo correctamente.');     
      this.router.url;
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          this.router.navigate([this.router.url]);
      });  
      },
      error :(err) => {
           this.swal.error('Error al guardar la tarea'); 
      },
    })
  }




  public IsBtnClose: boolean = true;
  public taskIdUp!: number;


  public getTaskId(): void{


     const url = this.router.url;

     if(url.includes("informationTask")){
      this.IsBtnClose = false;
      this.taskIdUp = Number(url.split("/")[3]);
      this.api.getAppNSerio(`Task/GetTasksById?id=${this.taskIdUp}`).subscribe({
        next: (res) => {
          this.formTask.patchValue({
            ...res[0],
            dueDate:res[0].dueDate?.split('T')[0]
          });
        },
        error: (err) =>  {
          
        },
      })
     }
  }




}