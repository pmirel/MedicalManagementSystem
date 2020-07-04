import { Component, OnInit } from '@angular/core';
import { Patient } from '../patients.models';
import { PatientsService } from '../patients.service';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.css']
})
export class PatientsListComponent implements OnInit {

  public displayedColumns: string[] = ['firstName', 'lastName', 'cnp','action'];
  public patients: Patient[];


  constructor(private patientsService: PatientsService) {
  }

  ngOnInit() {
    this.loadPatients();
  }

  loadPatients() {
    this.patientsService.listPatients().subscribe(res => {
      this.patients = res;

    });
  }

  deletePatient(patient: Patient) {
    this.patientsService.deletePatient(patient.id).subscribe(x => {
      this.loadPatients();
    });
  }
}
