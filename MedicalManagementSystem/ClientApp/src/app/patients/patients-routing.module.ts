import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientsEditComponent } from './patients-edit/patients-edit.component';
import { PatientsListComponent } from './patients-list/patients-list.component';
import { Routes, RouterModule } from '@angular/router';
import { PatientsComponent } from './patients.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';


const routes: Routes = [
  {
    path: '', component: PatientsComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: PatientsListComponent },
      { path: 'edit/:id', component: PatientsEditComponent },
      { path: 'edit', component: PatientsEditComponent },
      { path: 'details/:id', component: PatientDetailsComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientsRoutingModule {
  static routedComponents = [PatientsComponent, PatientsListComponent, PatientsEditComponent, PatientDetailsComponent];
}
