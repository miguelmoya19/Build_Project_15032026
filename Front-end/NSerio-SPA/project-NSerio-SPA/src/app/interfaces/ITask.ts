export interface ITask {
  id: number;
  title: string;
  assignedTo: string;
  status: string;
  priority: string;
  estimatedComplexity: number;
  creationDate: Date;
  dueDate: Date;
  projectId: number;
}