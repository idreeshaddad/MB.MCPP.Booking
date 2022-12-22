import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';
import { Lookup } from '../models/lookup.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl = `${environment.apiUrl}/Customers`;

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {

    return this.http.get<Customer[]>(`${this.apiUrl}/GetCustomers`);
  }

  getCustomer(id: number): Observable<Customer> {

    return this.http.get<Customer>(`${this.apiUrl}/GetCustomer/${id}`);
  }

  createCustomer(customer: Customer): Observable<Customer> {

    return this.http.post<Customer>(`${this.apiUrl}/CreateCustomer`, customer)
  }

  editCustomer(id: number, customer: Customer): Observable<any> {

    return this.http.put<Customer>(`${this.apiUrl}/EditCustomer/${id}`, customer)
  }

  deleteCustomer(id: number): Observable<any> {

    return this.http.delete<Customer>(`${this.apiUrl}/DeleteCustomer/${id}`)
  }

  getCustomerLookup(): Observable<Lookup[]> {

    return this.http.get<Lookup[]>(`${this.apiUrl}/GetLookup`);
  }

}
