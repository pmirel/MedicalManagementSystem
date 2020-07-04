import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorsRoutingModule } from './doctors-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DoctorsService } from './doctors.service';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';


@NgModule({
  declarations: [DoctorsRoutingModule.routedComponents],
  imports: [
    CommonModule,
    DoctorsRoutingModule,
    AngularMaterialModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DoctorsService]
})
export class DoctorsModule { }
