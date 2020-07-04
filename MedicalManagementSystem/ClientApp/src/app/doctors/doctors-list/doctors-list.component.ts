import { Component, OnInit } from '@angular/core';
import { Doctor } from '../doctors.models';
import { DoctorsService } from '../doctors.service';
import { PaginatedDoctors } from '../paginatedDoctors.models';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent implements OnInit {

  public displayedColumns: string[] = ['firstName', 'lastName', 'speciality', 'action', 'patients'];
  public doctors: PaginatedDoctors;
  public pageEvent: PageEvent;


  constructor(private doctorsService: DoctorsService) {
  }

  ngOnInit() {
    this.loadDoctors(null);
  }

  loadDoctors(event?: PageEvent) {
    this.doctorsService.listDoctors(event).subscribe(res => {
      this.doctors = res;

    });
  }

  deleteDoctor(doctor: Doctor) {
    this.doctorsService.deleteDoctor(doctor.id).subscribe(x => {
      this.loadDoctors();
    });
  }
}
