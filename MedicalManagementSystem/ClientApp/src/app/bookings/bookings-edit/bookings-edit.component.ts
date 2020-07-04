import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BookingsService } from '../bookings.service';
import { Booking } from '../bookings.models';

@Component({
  selector: 'app-bookings-edit',
  templateUrl: './bookings-edit.component.html',
  styleUrls: ['./bookings-edit.component.css']
})
export class BookingsEditComponent implements OnInit {
  private routerLink: string = '../list';

  private bookingID: number;

  private isEdit: boolean = false;

  public formGroup: FormGroup;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private bookingsService: BookingsService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.bookingID = parseInt(this.route.snapshot.params['id']);

    if (this.bookingID) {
      this.routerLink = '../../list';

      this.bookingsService.getBooking(this.bookingID).subscribe(res => {
        this.initForm(res);
        this.isEdit = true;
      });
    }
    else {
      this.initForm(<Booking>{});
    }
  }

  save() {
    Object.keys(this.formGroup.controls).forEach(control => {
      this.formGroup.get(control).markAsTouched();
    });

    if (this.formGroup.valid) {
      let booking = this.formGroup.value as Booking;

      if (this.isEdit) {
        booking.id = this.bookingID;

        this.bookingsService.modifyBooking(booking).subscribe(res => {
          this.router.navigate(['/bookings']);
        });
      } else {

        this.bookingsService.saveBooking(booking).subscribe(res => {
          this.router.navigate(['/bookings']);
        });
      }
    }
  }

  initForm(booking: Booking) {
    this.formGroup = this.formBuilder.group({

      location: [booking.location, Validators.required],
      doctorId: [booking.doctorId, Validators.required],
      patientId: [booking.patientId, Validators.required]
   
    });
  }

}
