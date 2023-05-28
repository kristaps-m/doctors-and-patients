import { Component, EventEmitter, Output, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  theDoctorId?:number = 0;

  constructor(
    private patientService: PatientService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id){
        this.theDoctorId = +id;
      }

      // if (id) {
      //   // const doctor = this.DoctorService.getOneDoctor(+id);
      //   // this.oneDoctor = doctor;
      //   // this.DoctorPatientService.getSpecialDoctorPatientByDoctorId(
      //   //   +id
      //   // ).subscribe(
      //   //   (result: IDoctorPatient[]) => (this.doctorPatients = result)
      //   // );

      //   // this.ApartmentDtoService.getApartmentDTOs().subscribe(
      //   //   (result: IApartmentDTO[]) => (this.apartmentDTOs = result)
      //   // );

      //   // this.PatientService.getPatientByDoctorId(+id).subscribe(
      //   //   (result: IPatient[]) => (this.patientByDoctorId = result)
      //   );
      // }
    });
  }

  createPatient(patient: IPatient) {
    this.patientService
      .createPatient(patient)
      .subscribe((p: IPatient) => this.patientUpdated.emit(p));
  }

  createPatientAndDoctorPatient(patient: IPatient, doctorId: number) {
    this.patientService
      .createPatientAndDoctorPatient(patient, doctorId)
      .subscribe((p: IPatient) => this.patientUpdated.emit(p));
  }
}
