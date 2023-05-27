import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AllDoctorsComponent } from './components/all-doctors/all-doctors.component';
import { AllPatientsComponent } from './components/all-patients/all-patients.component';

@NgModule({
  declarations: [AppComponent, AllDoctorsComponent, AllPatientsComponent],
  imports: [BrowserModule, AppRoutingModule, NgbModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
