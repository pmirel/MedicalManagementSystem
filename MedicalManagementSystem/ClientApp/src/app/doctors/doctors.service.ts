
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Doctor } from './doctors.models';
import { ApplicationService } from '../core/services/application.service';
//import { PaginatedExpenses } from './paginatedExpenses.models';
//import { PageEvent } from '@angular/material/paginator';


@Injectable()
export class DoctorsService {

  constructor(
    private http: HttpClient,
    private applicationService: ApplicationService) { }

  getDoctor(id: number) {
    return this.http.get<Doctor>(`${this.applicationService.baseUrl}api/Doctors/${id}`);
  }

  listDoctors() {
    return this.http.get<Doctor[]>(`${this.applicationService.baseUrl}api/Doctors`);
  }

  saveDoctor(doctor: Doctor) {
    return this.http.post(`${this.applicationService.baseUrl}api/Doctors`, doctor);
  }

  modifyDoctor(doctor: Doctor) {
    return this.http.put(`${this.applicationService.baseUrl}api/Doctors/${doctor.id}`, doctor);
  }

  deleteDoctor(id: number) {
    return this.http.delete<any>(`${this.applicationService.baseUrl}api/Doctors/${id}`);
  }
}

