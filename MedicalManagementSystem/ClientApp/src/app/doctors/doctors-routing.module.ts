import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorsEditComponent } from './doctors-edit/doctors-edit.component';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { Routes, RouterModule } from '@angular/router';
import { DoctorsComponent } from './doctors.component';


const routes: Routes = [
  {
    path: '', component: DoctorsComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: DoctorsListComponent },
      { path: 'edit/:id', component: DoctorsEditComponent },
      { path: 'edit', component: DoctorsEditComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorsRoutingModule {
  static routedComponents = [DoctorsComponent, DoctorsListComponent, DoctorsEditComponent];
}
