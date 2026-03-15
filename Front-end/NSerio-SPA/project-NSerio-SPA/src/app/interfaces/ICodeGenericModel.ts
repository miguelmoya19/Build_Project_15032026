export interface ProjectStatus {
  statusProjectId: number;
  statusProject: string;
}

export interface TaskStatus {
  statusTaskId: number;
  statusTask: string;
}

export interface Developer {
  developerId: number;
  fullName: string;
}

export interface PriorityStatus {
  statusPriorityId: number;
  statusPriority: string;
}


export interface ResponseModelGenericStatus{
    projects:ProjectStatus[],
    tasks:TaskStatus[],
    developers:Developer[],
    priority:PriorityStatus[]
}
