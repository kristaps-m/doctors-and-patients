import { Component } from '@angular/core';
import { IPatient } from 'src/app/models/Patient';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-all-patients',
  templateUrl: './all-patients.component.html',
  styleUrls: ['./all-patients.component.css'],
})
export class AllPatientsComponent {
  allPatients: IPatient[] = [];

  constructor(private patientService: PatientService) {}

  ngOnInit(): void {
    this.patientService.getAllPatients().subscribe((data: IPatient[]) => {
      this.allPatients = data;
    });
  }
}
