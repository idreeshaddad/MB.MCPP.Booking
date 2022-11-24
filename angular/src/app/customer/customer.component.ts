import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Gender } from '../enums/gender.enum';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { DeleteCustomerComponent } from './delete-customer/delete-customer.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [];
  gender = Gender;
  showSpinner: boolean = true;

  constructor(
    private customerSvc: CustomerService,
    public dialog: MatDialog) { }

  ngOnInit(): void {

    this.loadCustomers();
  }

  deleteCustomer(id: number): void {

    let deleteDialogConfig: MatDialogConfig = {
      data: {
        customer: this.customers.find(c => c.id == id)
      },
      disableClose: true
    };

    const dialogRef = this.dialog.open(DeleteCustomerComponent, deleteDialogConfig);

    dialogRef.afterClosed().subscribe(result => {

      if (result == true) {

        this.showSpinner = true;

        this.customerSvc.deleteCustomer(id).subscribe({
          next: () => {
            this.loadCustomers();
          }
        });
      }

    });
  }


  //#region Private Functions

  private loadCustomers() {

    this.customerSvc.getCustomers().subscribe(
      customersFromApi => {
        this.customers = customersFromApi;
        this.showSpinner = false;
      }
    );
  }

  //#endregion
}
