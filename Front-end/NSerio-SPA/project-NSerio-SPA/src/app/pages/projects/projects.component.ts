import { Component, OnInit, ViewChild } from '@angular/core';
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
import { tap } from 'rxjs';
import { LoadInformationInitialService } from 'src/app/services/load-information-initial.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit {
  public projectId: number | undefined;
  public displayedColumns: string[] = [];
  private pageSize: number = 0;
  public data: IFilterTaskModel[] = [];
  public tasksInformation: TaskStatus[] = [];
  public devInformation: Developer[] = [];
  public countPageSize: number = 0;
  public countBtn: number = 1;

  constructor(
    private route: ActivatedRoute,
    private apiService: NserioApiService,
    private dialog: MatDialog,
    private readonly loadInformation: LoadInformationInitialService,
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.projectId = +params?.get('id');
      this.loadTasks();
      this.loadAsync();
    });
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
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
    this.apiService
      .getAppNSerio(
        `v1/Project/${this.projectId}/tasks?assigneeId=-1&page=${this.pageSize}`,
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
}