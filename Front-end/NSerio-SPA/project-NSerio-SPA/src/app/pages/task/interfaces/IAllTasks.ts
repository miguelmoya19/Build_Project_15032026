export interface IAllTasks {
  taskId: number;
  name: string;
  title: string;
  description: string;
  assignee: string;
  priority: string;
  estimatedComplexity: number;
  dueDate: string;
}


export type IAllTasksSpanish = {
  "taskId",
  "Asignado a",
  "Complejidad Estimada",
  "Descripción",
  "Estado",
  "Fecha de vencimiento",
  "Prioridad",
  "Proyecto",
  "Título"
}