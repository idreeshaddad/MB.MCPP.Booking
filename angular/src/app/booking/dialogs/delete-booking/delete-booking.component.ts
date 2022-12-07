import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BookingList } from 'src/app/models/booking/bookingList.model';

@Component({
  selector: 'app-delete-booking',
  templateUrl: './delete-booking.component.html',
  styleUrls: ['./delete-booking.component.css']
})
export class DeleteBookingComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: BookingList) { }

  ngOnInit(): void {


  }

}
