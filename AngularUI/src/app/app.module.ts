import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AllDoctorsComponent } from './components/all-doctors/all-doctors.component';
import { AllPatientsComponent } from './components/all-patients/all-patients.component';
import { EditPatientComponent } from './components/edit-patient/edit-patient.component';
import { FormsModule } from '@angular/forms';
import { DoctorComponent } from './components/doctor/doctor.component';
import { HomepageComponent } from './components/homepage/homepage.component';

@NgModule({
  declarations: [
    AppComponent,
    AllDoctorsComponent,
    AllPatientsComponent,
    EditPatientComponent,
    DoctorComponent,
    HomepageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
