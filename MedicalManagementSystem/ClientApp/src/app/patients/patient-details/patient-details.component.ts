import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit {

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
  prescritions: Prescription[];
}

interface Prescription {
  diagnosis: string;
  description: string;
  dateAdded: string;
  price: number
  patientId: number;
}
