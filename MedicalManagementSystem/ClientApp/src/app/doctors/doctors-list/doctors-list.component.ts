import { Component, OnInit } from '@angular/core';
import { Doctor } from '../doctors.models';
import { DoctorsService } from '../doctors.service';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent implements OnInit {

  public displayedColumns: string[] = ['firstName', 'lastName', 'speciality','action','patients'];
  public doctors: Doctor[];


  constructor(private doctorsService: DoctorsService) {
  }

  ngOnInit() {
    this.loadDoctors();
  }

  loadDoctors() {
    this.doctorsService.listDoctors().subscribe(res => {
      this.doctors = res;

    });
  }

  deleteDoctor(doctor: Doctor) {
    this.doctorsService.deleteDoctor(doctor.id).subscribe(x => {
      this.loadDoctors();
    });
  }
}
