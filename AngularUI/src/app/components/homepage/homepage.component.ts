import { Component } from '@angular/core';
import { IPatient, Patient } from 'src/app/models/Patient';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
})
export class HomepageComponent {
  patientToEdit?: IPatient;

  initNewPatien() {
    this.patientToEdit = new Patient();
  }

  updateOneHouse(h: IPatient) {
    this.patientToEdit = h;
  }
}
