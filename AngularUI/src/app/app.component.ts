import { Component } from '@angular/core';
import { IPatient, Patient } from './models/Patient';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'AngularUI';
  patientToEdit?: IPatient;

  initNewPatien() {
    this.patientToEdit = new Patient();
  }

  updateOneHouse(h: IPatient) {
    this.patientToEdit = h;
  }
}
