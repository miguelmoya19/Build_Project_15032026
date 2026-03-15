export interface IProjectHealth {
  projectId: number;
  name: string;
  clientName: string;
  status: string;
  openTasks: number;
  completedTasks: number;
  totalTasks: number;
}