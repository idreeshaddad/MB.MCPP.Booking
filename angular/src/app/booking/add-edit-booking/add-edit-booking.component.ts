import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Booking } from 'src/app/models/booking/booking.model';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-add-edit-booking',
  templateUrl: './add-edit-booking.component.html',
  styleUrls: ['./add-edit-booking.component.css']
})
export class AddEditBookingComponent implements OnInit {

  bookingId?: number;
  booking?: Booking;
  bookingForm!: FormGroup;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;

  constructor(
    private bookingSvc: BookingService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {

    this.setBookingId();
    this.setPageMode();
    this.buildForm();
  }

  //#region Private Methods

  private setBookingId(): void {

    this.bookingId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private setPageMode(): void {

    if (this.bookingId) {

      this.pageMode = PageMode.Edit;
    }
  }

  private buildForm(): void {

    this.bookingForm = this.fb.group({
      id: [0],
      bookingStart: ['', Validators.required],
    });
  }

  //#endregion

}
