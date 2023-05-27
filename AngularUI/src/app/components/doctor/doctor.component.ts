import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Doctor } from 'src/app/models/Doctor';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css'],
})
export class DoctorComponent {
  oneDoctor: Observable<Doctor> | undefined;

  constructor(
    private DoctorService: DoctorService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');

      if (id) {
        const doctor = this.DoctorService.getOneDoctor(+id);
        this.oneDoctor = doctor;
        // this.HouseApartmentService.getSpecialHouseApartment(+id).subscribe(
        //   (result: IHouseApartment[]) => (this.houseApartments = result)
        // );

        // this.ApartmentDtoService.getApartmentDTOs().subscribe(
        //   (result: IApartmentDTO[]) => (this.apartmentDTOs = result)
        // );

        // this.ApartmentDtoService.getApartmentByHouseIdDTOs(+id).subscribe(
        //   (result: IApartmentDTO[]) => (this.apartmentDTOsByHouseId = result)
        // );
      }
    });
  }
}
