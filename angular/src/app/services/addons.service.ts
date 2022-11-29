import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Addon } from '../models/addon.model';
import { Lookup } from '../models/lookup.model';

@Injectable({
  providedIn: 'root'
})
export class AddonService {

  apiUrl = 'https://localhost:44368/api/Addons'

  constructor(private http: HttpClient) { }

  getAddons(): Observable<Addon[]> {

    return this.http.get<Addon[]>(`${this.apiUrl}/GetAddons`);
  }

  getAddonLookup(): Observable<Lookup[]> {

    return this.http.get<Lookup[]>(`${this.apiUrl}/GetLookup`);
  }

  getAddon(id: number): Observable<Addon> {

    return this.http.get<Addon>(`${this.apiUrl}/GetAddon/${id}`);
  }

  createAddon(addon: Addon): Observable<Addon> {

    return this.http.post<Addon>(`${this.apiUrl}/CreateAddon`, addon)
  }

  editAddon(id: number, addon: Addon): Observable<any> {

    return this.http.put<Addon>(`${this.apiUrl}/EditAddon/${id}`, addon)
  }

  deleteAddon(id: number): Observable<any> {

    return this.http.delete<Addon>(`${this.apiUrl}/DeleteAddon/${id}`)
  }
}
