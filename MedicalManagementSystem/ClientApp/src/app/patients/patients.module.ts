import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientsRoutingModule } from './patients-routing.module';
import { PatientsService } from './patients.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';
import { PatientsDetailsComponent } from './patients-details/patients-details.component';


@NgModule({
  declarations: [PatientsRoutingModule.routedComponents, PatientsDetailsComponent],
  imports: [
    CommonModule,
    PatientsRoutingModule,
    AngularMaterialModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [PatientsService]
})
export class PatientsModule { }
