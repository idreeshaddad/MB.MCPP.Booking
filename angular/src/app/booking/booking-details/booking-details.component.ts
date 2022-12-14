import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingDetails } from 'src/app/models/booking/bookingDetails.model';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {

  bookingId!: number;
  booking!: BookingDetails;

  constructor(
    private bookingSvc: BookingService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.loadBooking();
  }

  private loadBooking() {

    this.bookingId = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    if (this.bookingId) {

      this.bookingSvc.getBooking(this.bookingId).subscribe({
        next: (bookingFromApi) => {
          this.booking = bookingFromApi;
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      });
    }

  }
}
