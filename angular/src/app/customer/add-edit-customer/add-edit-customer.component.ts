import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(
    private customerSvc: CustomerService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setCustomerId();
    this.buildForm();

    if (this.customerId) {
      // TODO this is EDIT mode => get the customer and PATCH the reactive form with the values
    }
  }

  submitForm() {

    if (this.customerForm.valid) {

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

  //#region Private Methods

  private buildForm() {

    this.customerForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      gender: ['', Validators.required],
      dob: ['', Validators.required]
    });
  }

  private setCustomerId(): void {

    this.customerId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  //#endregion

}
