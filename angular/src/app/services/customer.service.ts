import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl = 'https://localhost:44368/api/Customers'

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

}
