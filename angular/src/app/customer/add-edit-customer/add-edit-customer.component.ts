import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from 'src/app/enums/gender.enum';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css']
})
export class AddEditCustomerComponent implements OnInit {

  customerId?: number;
  customer?: Customer;
  customerForm!: FormGroup;
  genderEnum = Gender;

  constructor(
    private customerSvc: CustomerService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setCustomerId();

    this.buildForm();

    if (this.customerId) {

      this.loadCustomer();
    }
  }

  submitForm() {

    if (this.customerForm.valid) {

      if (this.customerId) {

        this.customerSvc.editCustomer(this.customerId!, this.customerForm.value).subscribe({
          next: () => {
            this.router.navigate(['/customers']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
          }
        });
      }
      else {
        this.customerSvc.createCustomer(this.customerForm.value).subscribe({
          next: (customerFromApi) => {
            this.router.navigate(['/customers']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
          }
        });
      }
    }
  }

  //#region Private Methods

  private buildForm() {

    this.customerForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      gender: ['', Validators.required],
      dob: ['', Validators.required]
    });
  }

  private setCustomerId(): void {

    this.customerId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private loadCustomer() {

    this.customerSvc.getCustomer(this.customerId!).subscribe({
      next: (customerFromApi) => {
        this.patchForm(customerFromApi);
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      }
    });
  }

  private patchForm(customerFromApi: Customer) {

    this.customerForm.patchValue({
      id: customerFromApi.id,
      name: customerFromApi.name,
      gender: customerFromApi.gender,
      dob: customerFromApi.dob
    });
  }

  //#endregion

}