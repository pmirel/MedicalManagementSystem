import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patients-details',
  templateUrl: './patients-details.component.html',
  styleUrls: ['./patients-details.component.css']
})
export class PatientsDetailsComponent implements OnInit {

  private patient: PatientWithDetails;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute,
  ) {

  }

  loadPatient(patientId: string) {
    this.http.get<PatientWithDetails>(this.baseUrl + 'api/Patients/' + patientId).subscribe(result => {


      this.patient = result;

      console.log(this.patient);
    }, error => console.error(error));
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.loadPatient(params.get('patientId'));
    });

  }

}


interface PatientWithDetails {
  firstName: string;
  lastName: string;
  cnp: string;
  adress: string;
  email: string;
  prescriptions: Prescription[];
}

interface Prescription {
  diagnosis: string;
  description: string;
  dateAdded: Date;
  price: number;
  patientId: number;
}


