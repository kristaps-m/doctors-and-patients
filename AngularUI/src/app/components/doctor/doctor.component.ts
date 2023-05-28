import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Doctor } from 'src/app/models/Doctor';
import { IDoctorPatient } from 'src/app/models/DoctorPatient';
import { IPatient, Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';
import { DoctorPatientService } from 'src/app/services/doctorPatient.service';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css'],
})
export class DoctorComponent {
  oneDoctor: Observable<Doctor> | undefined;
  patientToEdit?: IPatient;
  //doctorPatients: IDoctorPatient[] = [];
  patientByDoctorId: IPatient[] = [];
  constructor(
    private DoctorService: DoctorService,
    private DoctorPatientService: DoctorPatientService,
    private PatientService: PatientService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');

      if (id) {
        const doctor = this.DoctorService.getOneDoctor(+id);
        this.oneDoctor = doctor;
        // this.DoctorPatientService.getSpecialDoctorPatientByDoctorId(
        //   +id
        // ).subscribe(
        //   (result: IDoctorPatient[]) => (this.doctorPatients = result)
        // );

        // this.ApartmentDtoService.getApartmentDTOs().subscribe(
        //   (result: IApartmentDTO[]) => (this.apartmentDTOs = result)
        // );

        this.PatientService.getPatientByDoctorId(+id).subscribe(
          (result: IPatient[]) => (this.patientByDoctorId = result)
        );
      }
    });
  }

  initNewPatien() {
    this.patientToEdit = new Patient();
  }

  updateOnePatient(h: IPatient) {
    this.patientToEdit = h;
  }
}
