export interface IDoctor {
  id?: number;
  name: string;
  lastName: string;
}

export class Doctor implements IDoctor {
  id?: number;
  name!: string;
  lastName!: string;
}
