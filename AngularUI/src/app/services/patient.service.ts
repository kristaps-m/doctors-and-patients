import { Injectable } from '@angular/core';
import { IPatient } from '../models/Patient';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  constructor(private http: HttpClient) {}

  public getAllPatients(): Observable<IPatient[]> {
    return this.http.get<IPatient[]>(`${environment.apiUri}/api/Patient/all`);
  }

  public createPatient(patient: IPatient): Observable<IPatient> {
    return this.http.post<IPatient>(
      `${environment.apiUri}/api/Patient/add`,
      patient
    );
  }

  public getPatientByDoctorId(id: number): Observable<IPatient[]> {
    let x = this.http.get<IPatient[]>(
      `${environment.apiUri}/api/Patient/doctor/${id}`
    );

    return x;
  }
}
