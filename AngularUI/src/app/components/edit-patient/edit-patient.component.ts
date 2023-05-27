import { Component, EventEmitter, Output, Input } from '@angular/core';
import { IPatient } from 'src/app/models/Patient';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css'],
})
export class EditPatientComponent {
  @Input() patient?: IPatient;
  @Output() patientUpdated = new EventEmitter<IPatient>();

  constructor(private patientService: PatientService) {}

  createPatient(patient: IPatient) {
    this.patientService
      .createPatient(patient)
      .subscribe((p: IPatient) => this.patientUpdated.emit(p));
  }
}
