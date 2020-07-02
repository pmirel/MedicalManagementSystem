import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public doctors: Doctor[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    http.get<Doctor[]>(baseUrl + 'api/Doctors').subscribe(result => {
      this.doctors = result;
      console.log(this.doctors);
    }, error => console.error(error));
  }

  
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
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
