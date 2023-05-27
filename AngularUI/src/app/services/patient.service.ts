import { Injectable } from '@angular/core';
import { IPatient } from '../models/Patient';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  constructor(private http: HttpClient) {}

  public getAllPatients(): Observable<IPatient[]> {
    return this.http.get<IPatient[]>(`https://localhost:4444/api/Patient/all`);
  }
}
