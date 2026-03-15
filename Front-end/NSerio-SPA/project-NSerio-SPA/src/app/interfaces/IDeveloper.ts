export interface IDeveloper {
  developerId: number;
  firstName: string;
  lastName: string;
  createdAt: string;
  isActive: boolean;
  email: IEmail;
}

export interface IEmail {
  valueEmail: string;
}
