import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddOn } from '../models/addon.model';
import { Lookup } from '../models/lookup.model';

@Injectable({
  providedIn: 'root'
})
export class AddOnService {

  apiUrl = 'https://localhost:44368/api/AddOns'

  constructor(private http: HttpClient) { }

  getAddOns(): Observable<AddOn[]> {

    return this.http.get<AddOn[]>(`${this.apiUrl}/GetAddOns`);
  }

  getAddOnLookup(): Observable<Lookup[]> {

    return this.http.get<Lookup[]>(`${this.apiUrl}/GetLookup`);
  }

  getAddOn(id: number): Observable<AddOn> {

    return this.http.get<AddOn>(`${this.apiUrl}/GetAddOn/${id}`);
  }

  createAddOn(addon: AddOn): Observable<AddOn> {

    return this.http.post<AddOn>(`${this.apiUrl}/CreateAddOn`, addon)
  }

  editAddOn(id: number, addon: AddOn): Observable<any> {

    return this.http.put<AddOn>(`${this.apiUrl}/EditAddOn/${id}`, addon)
  }

  deleteAddOn(id: number): Observable<any> {

    return this.http.delete<AddOn>(`${this.apiUrl}/DeleteAddOn/${id}`)
  }
}
