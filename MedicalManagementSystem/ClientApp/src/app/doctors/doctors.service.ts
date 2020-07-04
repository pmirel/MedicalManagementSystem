
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Doctor } from './doctors.models';
import { ApplicationService } from '../core/services/application.service';
import { PaginatedDoctors } from './paginatedDoctors.models';
import { PageEvent } from '@angular/material';

@Injectable()
export class DoctorsService {

  constructor(
    private http: HttpClient,
    private applicationService: ApplicationService) { }

  getDoctor(id: number) {
    return this.http.get<Doctor>(`${this.applicationService.baseUrl}api/Doctors/${id}`);
  }

  listDoctors(event?: PageEvent) {
    let pageIndex = event ? event.pageIndex + "" : "0";
    let itemsPerPage = event ? event.pageSize + "" : "5";
    console.log(event);
    let params = new HttpParams().set("page", pageIndex).set("itemsPerPage", itemsPerPage); //Create new HttpParams
    return this.http.get<PaginatedDoctors>(`${this.applicationService.baseUrl}api/Doctors`, { params: params });
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

