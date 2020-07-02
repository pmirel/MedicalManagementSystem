import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {  
  public doctors: Doctor[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadDoctors();
  }

  loadDoctors() {
    this.http.get<Doctor[]>(this.baseUrl + 'api/Doctors').subscribe(result => {
      this.doctors = result;
      console.log(this.doctors);
    }, error => console.error(error));
  }

  
}


interface Doctor {
  firstName: string;
  LastName: string;
  Speciality: Speciality;
}

enum Speciality {
  Other = 0,
  Family = 1,
  Internal = 2,
  Neurology = 3,
  Emergency = 4,
  Dermatology = 5
}
