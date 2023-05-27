import { Component } from '@angular/core';
import { IDoctor } from 'src/app/models/Doctor';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-all-doctors',
  templateUrl: './all-doctors.component.html',
  styleUrls: ['./all-doctors.component.css']
})
export class AllDoctorsComponent {
  allDoctors: IDoctor[] = [];

  constructor(
    private doctorService:DoctorService
  ) {   
  }

  ngOnInit() :void {
    this.doctorService.getAllDoctors().subscribe((data:IDoctor[]) => {
      this.allDoctors = data;
    });
  }
}
