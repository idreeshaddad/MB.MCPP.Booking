import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking/booking.model';
import { BookingList } from '../models/booking/bookingList.model';
import { Lookup } from '../models/lookup.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  apiUrl = 'https://localhost:44368/api/Bookings'

  constructor(private http: HttpClient) { }

  getBookings(): Observable<BookingList[]> {

    return this.http.get<BookingList[]>(`${this.apiUrl}/GetBookings`);
  }

  getBooking(id: number): Observable<Booking> {

    return this.http.get<Booking>(`${this.apiUrl}/GetBooking/${id}`);
  }

  createBooking(booking: Booking): Observable<Booking> {

    return this.http.post<Booking>(`${this.apiUrl}/CreateBooking`, booking)
  }

  editBooking(id: number, booking: Booking): Observable<any> {

    return this.http.put<Booking>(`${this.apiUrl}/EditBooking/${id}`, booking)
  }

  deleteBooking(id: number): Observable<any> {

    return this.http.delete<Booking>(`${this.apiUrl}/DeleteBooking/${id}`)
  }
}
