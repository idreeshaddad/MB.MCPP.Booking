import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lookup } from '../models/lookup.model';
import { Villa } from '../models/villas/villa.model';
import { VillaDetails } from '../models/villas/villaDetails.model';
import { VillaList } from '../models/villas/villaList.model';

@Injectable({
  providedIn: 'root'
})
export class VillaService {

  apiUrl = 'https://localhost:44368/api/Villas'

  constructor(private http: HttpClient) { }

  getVillas(): Observable<VillaList[]> {

    return this.http.get<VillaList[]>(`${this.apiUrl}/GetVillas`);
  }

  getVilla(id: number): Observable<VillaDetails> {

    return this.http.get<VillaDetails>(`${this.apiUrl}/GetVilla/${id}`);
  }

  createVilla(villa: Villa): Observable<Villa> {

    return this.http.post<Villa>(`${this.apiUrl}/CreateVilla`, villa)
  }

  getEditVilla(id: number): Observable<Villa> {

    return this.http.get<Villa>(`${this.apiUrl}/GetEditVilla/${id}`);
  }

  editVilla(id: number, villa: Villa): Observable<any> {

    return this.http.put<Villa>(`${this.apiUrl}/EditVilla/${id}`, villa)
  }

  deleteVilla(id: number): Observable<any> {

    return this.http.delete(`${this.apiUrl}/DeleteVilla/${id}`)
  }

  getVillaLookup(): Observable<Lookup[]> {

    return this.http.get<Lookup[]>(`${this.apiUrl}/GetLookup`);
  }
}
