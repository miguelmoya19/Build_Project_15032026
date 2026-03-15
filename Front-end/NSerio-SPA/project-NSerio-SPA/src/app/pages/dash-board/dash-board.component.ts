import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { IDeveloperWorkload } from 'src/app/interfaces/IDeveloperWorkload';
import { IProjectHealth } from 'src/app/interfaces/IProjectHealth';
import { NserioApiService } from 'src/app/services/nserio-api.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateTaskDialogComponent } from './modals/create-task-dialog.component';
import { ChartConfiguration, ChartType } from 'chart.js';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css'],
})
export class DashBoardComponent implements OnInit {
  now = new Date();

  public developerWorkload: IDeveloperWorkload[] = [];
  public dataProject: IProjectHealth[] = [];
  public displayColumnsDeveloper: string[] = [];
  public displayColumnsProject: string[] = [];
  public cards = [
    {
      icon: '📈',
      title: 'Visitas',
      subtitle: 'Últimas 24h',
      value: '4,220',
      tag: 'Up 12%',
      progress: 72,
      gradient: 'linear-gradient(135deg, #42a5f5, #7e57c2)',
    },
    {
      icon: '⚡',
      title: 'Tareas completadas',
      subtitle: 'En esta semana',
      value: '1,832',
      tag: 'En progreso',
      progress: 56,
      gradient: 'linear-gradient(135deg, #66bb6a, #00bfa5)',
    },
    {
      icon: '🧩',
      title: 'Nuevos registros',
      subtitle: 'Hoy',
      value: '318',
      tag: 'OK',
      progress: 84,
      gradient: 'linear-gradient(135deg, #ffca28, #ff7043)',
    },
  ];

  public barChartType: ChartType = 'bar';
  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    plugins: {
      legend: { display: false },
      tooltip: { enabled: true },
    },
    scales: {
      x: {
        grid: { display: false },
      },
      y: {
        beginAtZero: true,
        grid: { color: 'rgba(0,0,0,0.08)' },
      },
    },
  };
  public barChartLabels: string[] = ['Pendiente', 'En progreso', 'Completada'];
  public barChartData = {
    labels: this.barChartLabels,
    datasets: [
      {
        label: 'Tareas',
        data: [14, 8, 23],
        backgroundColor: ['#f5934d', '#6c5ce7', '#00b894'],
        borderRadius: 8,
      },
    ],
  };

  constructor(private readonly service: NserioApiService, private router: Router, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.getDeveloperWorkload();
  }

  public getDeveloperWorkload(): void {
    forkJoin([
      this.service.getAppNSerio('Dashboard/dashboard/developer-workload'),
      this.service.getAppNSerio('Dashboard/dashboard/project-health'),
    ]).subscribe({
      next: ([dataDev, dataProject]) => {
        this.developerWorkload = (
          dataDev as { data: IDeveloperWorkload[] }
        ).data;
        this.displayColumnsDeveloper = Object.keys(this.developerWorkload[0]);
        this.dataProject = (dataProject as { data: IProjectHealth[] }).data;
        this.displayColumnsProject = Object.keys(this.dataProject[0]);
      },
      error: (err) => {
        console.error('Error no se obtuvo la informacion adcuadamente.');
      },
    });
  }

  public rowStyleProject = (row: any): Record<string, string> => {
    if (row.openTasks > row.completedTasks) {
      return {
        backgroundColor: 'rgba(239, 68, 68, 0.12)',
        borderLeft: '4px solid #ef4444',
        fontWeight: '600'
      };
    }
    return {};
  };

  public onProjectAction(project: IProjectHealth) {
    this.router.navigate(['/projects', project.projectId]);
  }

  public openCreateTaskDialog(): void {
    this.dialog.open(CreateTaskDialogComponent, {
      width: '600px',
      maxWidth: '90vw',
      disableClose: false
    });
  }
}

