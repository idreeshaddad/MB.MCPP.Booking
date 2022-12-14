import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Booking } from 'src/app/models/booking/booking.model';
import { Lookup } from 'src/app/models/lookup.model';
import { BookingService } from 'src/app/services/booking.service';
import { CustomerService } from 'src/app/services/customer.service';
import { VillaService } from 'src/app/services/villa.service';
import { HttpErrorResponse } from '@angular/common/http';
import * as moment from 'moment';

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

  villaLookup!: Lookup[];
  customerLookup!: Lookup[];

  totalPrice: number = 0;

  constructor(
    private bookingSvc: BookingService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private villaSvc: VillaService,
    private customerSvc: CustomerService
  ) { }

  ngOnInit(): void {

    this.setBookingId();
    this.setPageMode();
    this.buildForm();

    if (this.bookingId) {

      this.loadBooking();
    }

    this.loadVillaLookup();
    this.loadCustomerLookup();

  }

  get villaId(): number {

    return Number(this.bookingForm.controls['villaId'].value);
  }

  get bookingStart(): string {

    return moment(this.bookingForm.controls['bookingStart'].value).toISOString();

  }

  get bookingEnd(): string {

    return moment(this.bookingForm.controls['bookingEnd'].value).toISOString();
  }

  updatePrice(): void {


    if (this.canUpdatePrice()) {

      console.log("UpdatePrice Invoked");

      this.bookingSvc.getBookingPrice(this.villaId, this.bookingStart, this.bookingEnd).subscribe({

        next: (totalPriceFromApi: number) => {
          this.totalPrice = totalPriceFromApi;
        }
      });
    }
  }

  submitForm(): void {

    if (this.bookingForm.valid) {

      if (this.pageMode == PageMode.Create) {

        this.bookingSvc.createBooking(this.bookingForm.value).subscribe({
          next: () => {
            this.router.navigate(['/bookings']);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err.message);
          }
        });
      }
      else {

        this.bookingSvc.editBooking(this.bookingId!, this.bookingForm.value).subscribe({
          next: () => {
            this.router.navigate(['/bookings']);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err.message);
          }
        });
      }
    }
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
      bookingEnd: ['', Validators.required],
      numberOfOccupants: ['', Validators.required],
      villaId: ['', Validators.required],
      customerId: ['', Validators.required]
    });
  }

  private loadVillaLookup() {

    this.villaSvc.getVillaLookup().subscribe({
      next: (villaLookupFromApi) => {
        this.villaLookup = villaLookupFromApi;
      }
    });
  }

  private loadCustomerLookup() {

    this.customerSvc.getCustomerLookup().subscribe({
      next: (customerLookupFromApi) => {
        this.customerLookup = customerLookupFromApi;
      }
    });
  }

  private loadBooking() {

    this.bookingSvc.getEditBooking(this.bookingId!).subscribe({
      next: (bookingFromApi: Booking) => {
        this.booking = bookingFromApi;
        this.bookingForm.patchValue(bookingFromApi);
        this.updatePrice();
      },
      error: (err: HttpErrorResponse) => {
        console.log(err.message);
      }
    });
  }

  private canUpdatePrice(): boolean {

    return this.villaId != 0 && this.bookingStart != '' && this.bookingEnd != '';
  }

  //#endregion

}
