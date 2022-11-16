import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Room } from '../models/room.model';
import { RoomService } from '../services/room.service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {

  rooms: Room[] = [];

  constructor(private roomSvc: RoomService) { }

  ngOnInit(): void {

    this.loadRooms();
  }

  loadRooms() {

    this.roomSvc.getRooms().subscribe({
      next: (roomsFromApi) => {
        this.rooms = roomsFromApi;
      },
      error: (e: HttpErrorResponse) => {
        console.log(`Error ${e}`);
      }
    });
  }

}
