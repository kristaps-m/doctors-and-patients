export interface IPatient {
  id?: number;
  name: string;
  lastName: string;
  dateOfBirth: Date;
  city: string;
}

export class Patient implements Patient {
  id?: number | undefined;
  name!: string;
  lastName!: string;
  dateOfBirth!: Date;
  city!: string;
}
