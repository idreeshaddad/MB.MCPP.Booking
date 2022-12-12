import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Booking } from 'src/app/models/booking/booking.model';
import { Lookup } from 'src/app/models/lookup.model';
import { Villa } from 'src/app/models/villas/villa.model';
import { BookingService } from 'src/app/services/booking.service';
import { CustomerService } from 'src/app/services/customer.service';
import { VillaService } from 'src/app/services/villa.service';

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

    this.loadVillaLookup();
    this.loadCustomerLookup();

  }

  submitForm(): void {

    throw new Error('Method not implemented.');
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

  //#endregion

}
