import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { NserioApiService } from '../../services/nserio-api.service';
import { ITask } from '../../interfaces/ITask';
import { TaskDetailDialogComponent } from './task-detail-dialog.component';
import { IFilterTaskModel } from 'src/app/interfaces/IFilterTaskModel';
import { responseModel } from 'src/app/Shared/responseModel';
import { Developer, ResponseModelGenericStatus, TaskStatus } from 'src/app/interfaces/ICodeGenericModel';
import { debounceTime, Subscription, tap } from 'rxjs';
import { LoadInformationInitialService } from 'src/app/services/load-information-initial.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit,OnDestroy {
  public projectId: number | undefined;
  public displayedColumns: string[] = [];
  private pageSize: number = 0;
  public data: IFilterTaskModel[] = [];
  public tasksInformation: TaskStatus[] = [];
  public devInformation: Developer[] = [];
  public countPageSize: number = 0;
  public countBtn: number = 1;
  public formFilter:FormGroup;
  private suscriptionStatus$: Subscription | undefined;
  private suscriptionDev$: Subscription | undefined;

  constructor(
    private route: ActivatedRoute,
    private apiService: NserioApiService,
    private dialog: MatDialog,
    private readonly loadInformation: LoadInformationInitialService,
    private readonly fb:FormBuilder
  ) {

    this.formFilter = this.fb.group({
       status:[null],
       dev:[null]
    })

  }

  ngOnDestroy(): void {
    if(this.suscriptionDev$) this.suscriptionDev$.unsubscribe();
    if(this.suscriptionStatus$) this.suscriptionStatus$.unsubscribe();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.projectId = +params?.get('id');
      this.loadTasks();
      this.loadAsync();
    });

    this.suscriptionStatus$ = this.formFilter.get("status").valueChanges.
      pipe(tap(() => {
        this.rebootValues()
      }),
       debounceTime(120)
    ).
      subscribe(() => this.loadTasks());

    this.suscriptionDev$ = this.formFilter.get("dev").valueChanges.
      pipe(tap((res) => {
        this.rebootValues()
        
      }),
       debounceTime(120)
     ).
      subscribe(() => this.loadTasks());
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  private rebootValues(): void {
    this.pageSize = 0;
    this.countPageSize = 0;
    this.countBtn = 1;
  }

  public loadAsync() {
    this.loadInformation.Initialnformation().subscribe({
      next: (res) => {
        this.devInformation = res.data.developers;
        this.tasksInformation = res.data.tasks;
      },
    });
  }

  public loadTasks() {

    const { dev,status } = this.formFilter.value;

    console.log(status);

    let url = `v1/Project/${this.projectId}/tasks?page=${this.pageSize}`;

    if (dev != null) {
      url += `&assigneeId=${dev}`;
    }

    if (status != null) {
      url += `&status=${status}`;
    }

    console.log(this.formFilter.value);

    this.apiService
      .getAppNSerio(
        url,
      )
      .subscribe({
        next: (
          res: responseModel<{ items: IFilterTaskModel[]; pageSize: number }>,
        ) => {
          this.data = res.data.items.map((s) => {
            return {
              ...s,
              'Creado a': s['Creado a'].split('T')[0],
              'Fecha de vencimiento': s['Fecha de vencimiento'].split('T')[0],
            };
          });
          this.displayedColumns = Object.keys(this.data[0]);
          this.countPageSize = res.data.pageSize;
        },
        error(err) {},
      });
  }

  public nextData(): void {

    console.log(this.formFilter);
    if (this.countBtn < this.countPageSize) {
      this.countBtn++;
      this.pageSize += 5;
      this.loadTasks();
    }
  }

  public previousData(): void {
    if (this.countBtn > 1) {
      this.countBtn--;
      this.pageSize -= 5;
      this.loadTasks();
    }
  }

  public clearFilter():void{
     this.rebootValues();
     this.formFilter.reset();
     this.loadTasks();
  }
}