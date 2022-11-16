import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Room } from 'src/app/models/room.model';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-add-edit-room',
  templateUrl: './add-edit-room.component.html',
  styleUrls: ['./add-edit-room.component.css']
})
export class AddEditRoomComponent implements OnInit {

  roomId?: number;
  room?: Room;
  roomForm!: FormGroup;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;

  constructor(
    private roomSvc: RoomService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setRoomId();
    this.setPageMode();

    this.buildForm();

    if (this.pageMode == PageMode.Edit) {

      this.loadRoom();
    }
  }

  submitForm(): void {

    if (this.roomForm.valid) {

      if (this.pageMode == PageMode.Create) {

        this.roomSvc.createRoom(this.roomForm.value).subscribe({

          next: () => {
            this.router.navigate(['/rooms']);
          },
          error: (e: HttpErrorResponse) => {

            console.log(`Error: ${e}`);
          }
        });
      }
      else {

        this.roomSvc.editRoom(this.roomId!, this.roomForm.value).subscribe({

          next: () => {
            this.router.navigate(['/rooms']);
          },
          error: (e: HttpErrorResponse) => {

            console.log(`Error: ${e}`);
          }
        });
      }
    }
  }

  //#region Private

  private loadRoom() {

    this.roomSvc.getRoom(this.roomId!).subscribe({
      next: (roomFromApi) => {
        this.room = roomFromApi;
        this.patchForm(roomFromApi);
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      }
    });
  }

  private setRoomId() {

    this.roomId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private setPageMode() {

    if (this.roomId) {

      this.pageMode = PageMode.Edit
    }
  }

  private buildForm() {

    this.roomForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      address: ['', Validators.required],
      rating: ['', Validators.required],
      numberOfOccupants: ['', Validators.required],
      price: ['', Validators.required],
      occupied: ['', Validators.required],
      //services: RoomService[],
    });
  }

  private patchForm(room: Room) {

    this.roomForm.patchValue({
      id: room.id,
      name: room.name,
      address: room.address,
      rating: room.rating,
      numberOfOccupants: room.numberOfOccupants,
      price: room.price,
      occupied: room.occupied
      //services: RoomService[],
    });
  }

  //#endregion

}
