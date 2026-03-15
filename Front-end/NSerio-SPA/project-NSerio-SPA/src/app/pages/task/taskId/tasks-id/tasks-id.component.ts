import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateTaskDialogComponent } from 'src/app/pages/dash-board/modals/create-task-dialog.component';

@Component({
  selector: 'app-tasks-id',
  templateUrl: './tasks-id.component.html',
  styleUrls: ['./tasks-id.component.css']
})
export class TasksIdComponent implements OnInit {


  constructor(private readonly dialog: MatDialog ){

  }

    ngOnInit(): void {
      this.openCreateTaskDialog()
    }



    public openCreateTaskDialog(): void {
      this.dialog.open(CreateTaskDialogComponent, {
        width: '600px',
        maxWidth: '90vw',
        disableClose: false
      });
    }

}
