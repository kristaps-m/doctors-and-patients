import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorComponent } from './components/doctor/doctor.component';
import { HomepageComponent } from './components/homepage/homepage.component';

const routes: Routes = [
  { path: ``, component: HomepageComponent },
  { path: `doctor/:id`, component: DoctorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
