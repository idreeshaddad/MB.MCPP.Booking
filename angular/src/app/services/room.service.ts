import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Room } from '../models/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  apiUrl = 'https://localhost:44368/api/Rooms'

  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {

    return this.http.get<Room[]>(`${this.apiUrl}/GetRooms`);
  }

  getRoom(id: number): Observable<Room> {

    return this.http.get<Room>(`${this.apiUrl}/GetRoom/${id}`);
  }

  createRoom(room: Room): Observable<Room> {

    return this.http.post<Room>(`${this.apiUrl}/CreateRoom`, room)
  }

  editRoom(id: number, room: Room): Observable<any> {

    return this.http.put<Room>(`${this.apiUrl}/EditRoom/${id}`, room)
  }

  deleteRoom(id: number): Observable<any> {

    return this.http.delete<Room>(`${this.apiUrl}/DeleteRoom/${id}`)
  }
}
