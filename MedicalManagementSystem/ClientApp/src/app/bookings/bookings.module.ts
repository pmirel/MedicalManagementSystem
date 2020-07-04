import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsEditComponent } from './bookings-edit/bookings-edit.component';
import { BookingsListComponent } from './bookings-list/bookings-list.component';
import { BookingsRoutingModule } from './bookings-routing.module';  
import { BookingsService } from './bookings.service'
import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [BookingsRoutingModule.routedComponents],
  imports: [
    CommonModule,
    BookingsRoutingModule,
    AngularMaterialModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [BookingsService],
})
export class BookingsModule { }
