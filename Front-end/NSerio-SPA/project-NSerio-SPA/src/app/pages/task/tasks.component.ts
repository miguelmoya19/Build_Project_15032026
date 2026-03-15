import { Component, OnInit, Type } from '@angular/core';
import { NserioApiService } from 'src/app/services/nserio-api.service';
import { IAllTasks } from '../../interfaces/IAllTasks';
import { responseModel } from 'src/app/Shared/responseModel';
import { MessageService } from 'src/app/services/message-service';
import { MatDialog } from '@angular/material/dialog';
import { CreateTaskDialogComponent } from '../dash-board/modals/create-task-dialog.component';
import { ChangeInformationService } from 'src/app/services/change-information.service';
import { tap } from 'rxjs';
import { Developer, PriorityStatus, ProjectStatus, ResponseModelGenericStatus, TaskStatus } from 'src/app/interfaces/ICodeGenericModel';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  public dataTasks: IAllTasks[]=[];
  public displayedColumns: string[] = [];

  constructor(private api: NserioApiService, 
    private swal: MessageService,
     private dialog: MatDialog,
    private readonly shared: ChangeInformationService<IAllTasks[]>, private readonly router: Router){


  }
  ngOnInit(): void {

    this.GetAllProjectInformation();
  }

  public GetAllProjectInformation(): void {
    this.api.getAppNSerio(`Task/allTasks`).subscribe({
      next: (res: responseModel<IAllTasks[]>) => {
        this.dataTasks = res?.data;
        this.displayedColumns = Object.keys(this.dataTasks[0]);        
      },
      error: (err) => {
        this.swal.error("Error", err.message);
      },
    })
  }



    public openCreateTaskDialog(event: IAllTasks): void {

      this.router.navigate([`${this.router.url}/informationTask/${event.taskId}`])
  
    }



}
