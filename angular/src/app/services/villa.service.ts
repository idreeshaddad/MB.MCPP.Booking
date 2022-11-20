import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Villa } from '../models/villa.model';

@Injectable({
  providedIn: 'root'
})
export class VillaService {

  apiUrl = 'https://localhost:44368/api/Villas'

  constructor(private http: HttpClient) { }

  getVillas(): Observable<Villa[]> {

    return this.http.get<Villa[]>(`${this.apiUrl}/GetVillas`);
  }

  getVilla(id: number): Observable<Villa> {

    return this.http.get<Villa>(`${this.apiUrl}/GetVilla/${id}`);
  }

  createVilla(villa: Villa): Observable<Villa> {

    return this.http.post<Villa>(`${this.apiUrl}/CreateVilla`, villa)
  }

  editVilla(id: number, villa: Villa): Observable<any> {

    return this.http.put<Villa>(`${this.apiUrl}/EditVilla/${id}`, villa)
  }

  deleteVilla(id: number): Observable<any> {

    return this.http.delete<Villa>(`${this.apiUrl}/DeleteVilla/${id}`)
  }
}
