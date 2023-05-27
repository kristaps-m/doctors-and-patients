import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDoctor } from '../models/Doctor';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  constructor(private http: HttpClient) {}

  public getAllDoctors(): Observable<IDoctor[]> {
    let x = this.http.get<IDoctor[]>(`https://localhost:4444/api/Doctor/all`);
    console.log(x);
    return x;
    // return this.http.get<IDoctor[]>(`https://localhost:4444/api/Doctor/all`);
  }
}
