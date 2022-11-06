import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [];

  constructor(private customerSvc: CustomerService) { }

  ngOnInit(): void {

    this.customerSvc.getCustomers().subscribe(
      customersFromApi => {
        this.customers = customersFromApi;
      }
    );
  }

}
