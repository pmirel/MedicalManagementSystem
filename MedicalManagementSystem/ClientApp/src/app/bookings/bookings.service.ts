
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Booking } from './bookings.models';
import { ApplicationService } from '../core/services/application.service';

@Injectable()
export class BookingsService {

  constructor(
    private http: HttpClient,
    private applicationService: ApplicationService) { }

  getBooking(id: number) {
    return this.http.get<Booking>(`${this.applicationService.baseUrl}api/Bookings/${id}`);
  }

  listBookings() {
    return this.http.get<Booking>(`${this.applicationService.baseUrl}api/Bookings`);
  }

  saveBooking(doctor: Booking) {
    return this.http.post(`${this.applicationService.baseUrl}api/Bookings`, doctor);
  }

  modifyBooking(doctor: Booking) {
    return this.http.put(`${this.applicationService.baseUrl}api/Bookings/${doctor.id}`, doctor);
  }

  deleteBooking(id: number) {
    return this.http.delete<any>(`${this.applicationService.baseUrl}api/Bookings/${id}`);

  }
}

