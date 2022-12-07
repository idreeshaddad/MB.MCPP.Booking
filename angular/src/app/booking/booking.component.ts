import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BookingList } from '../models/booking/bookingList.model';
import { BookingService } from '../services/booking.service';
import { DeleteBookingComponent } from './dialogs/delete-booking/delete-booking.component';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  bookings!: BookingList[];
  showSpinner: boolean = true;

  constructor(
    private bookingSvc: BookingService,
    private dialogSvc: MatDialog) { }

  ngOnInit(): void {

    this.loadBookings();
  }

  deleteBooking(booking: BookingList): void {

    const dialogRef = this.dialogSvc.open(DeleteBookingComponent, {
      data: booking,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe({

      next: (answer: Boolean) => {

        if (answer) {

          this.showSpinner = true;

          this.bookingSvc.deleteBooking(booking.id).subscribe({
            next: () => {
              this.loadBookings();
            },
            error: (err: HttpErrorResponse) => {
              alert(err.message);
              console.log(err);
            }
          });
        }
      }
    });
  }

  private loadBookings() {

    this.bookingSvc.getBookings().subscribe({
      next: (bookingsFromApi) => {
        this.bookings = bookingsFromApi;
        this.showSpinner = false;
      }
    });
  }

}
