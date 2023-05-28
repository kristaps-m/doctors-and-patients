import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IDoctorPatient } from '../models/DoctorPatient';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DoctorPatientService {
  constructor(private http: HttpClient) {}

  public getSpecialDoctorPatientByDoctorId(id: number): Observable<IDoctorPatient[]> {
        
    return this.http.get<IDoctorPatient[]>(
      `${environment.apiUri}/api/DoctorPatient/all/${id}`
    );;
  }
}
