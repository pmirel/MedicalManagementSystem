import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Speciality } from '../doctors/doctors.models';

@Component({
  selector: 'app-doctor-details',
  templateUrl: './doctor-details.component.html',
  styleUrls: ['./doctor-details.component.css']
})
export class DoctorDetailsComponent implements OnInit {

  private doctor: DoctorWithDetails;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute,
  ) {

  }

  loadDoctor(doctorId: string) {
    this.http.get<DoctorWithDetails>(this.baseUrl + 'api/Doctors/' + doctorId).subscribe(result => {


      this.doctor = result;

      console.log(this.doctor);
    }, error => console.error(error));
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.loadDoctor(params.get('doctorId'));
    });

  }

}


interface DoctorWithDetails {
  firstName: string;
  lastName: string;
  speciality: Speciality;
  patients: Patient[];
}

interface Patient {
  firstName: string;
  lastName: string;
  cnp: string;
  doctorId: number;
}

