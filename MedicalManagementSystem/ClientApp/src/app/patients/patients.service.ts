
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Patient } from './patients.models';
import { ApplicationService } from '../core/services/application.service';
//import { PaginatedExpenses } from './paginatedExpenses.models';
//import { PageEvent } from '@angular/material/paginator';


@Injectable()
export class PatientsService {

  constructor(
    private http: HttpClient,
    private applicationService: ApplicationService) { }

  getPatient(id: number) {
    return this.http.get<Patient>(`${this.applicationService.baseUrl}api/Patients/${id}`);
  }

 listPatients() {
   return this.http.get < Patient[]>(`${this.applicationService.baseUrl}api/Patients`);
 }

  savePatient(patient: Patient) {
    return this.http.post(`${this.applicationService.baseUrl}api/Patients`, patient);
  }

  modifyPatient(patient: Patient) {
    return this.http.put(`${this.applicationService.baseUrl}api/Patients/${patient.id}`, patient);
  }

  deletePatient(id: number) {
    return this.http.delete<any>(`${this.applicationService.baseUrl}api/Patients/${id}`);
  }
}

