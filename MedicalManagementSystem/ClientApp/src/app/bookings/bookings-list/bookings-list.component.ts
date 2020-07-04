import { Component, OnInit } from '@angular/core';
import { Booking } from '../bookings.models'
import { BookingsService } from '../bookings.service'
@Component({
  selector: 'app-bookings-list',
  templateUrl: './bookings-list.component.html',
  styleUrls: ['./bookings-list.component.css']
})
export class BookingsListComponent implements OnInit {
  public displayedColumns: string[] = ['location', 'dateOfBooking', 'status', 'doctorId', 'bookingId'];
  public bookings: Booking[];


  constructor(private bookingsService: BookingsService) {
  }

  ngOnInit() {
    this.loadBookings();
  }

  loadBookings() {
    this.bookingsService.listBookings().subscribe(res => {
      

    });
  }

  deleteBooking(booking: Booking) {
    this.bookingsService.deleteBooking(booking.id).subscribe(x => {
      this.loadBookings();
    });
  }
}
