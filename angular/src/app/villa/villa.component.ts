import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Villa } from '../models/villa.model';
import { VillaService } from '../services/villa.service';

@Component({
  selector: 'app-villa',
  templateUrl: './villa.component.html',
  styleUrls: ['./villa.component.css']
})
export class VillaComponent implements OnInit {

  villas: Villa[] = [];

  constructor(private villaSvc: VillaService) { }

  ngOnInit(): void {

    this.loadVillas();
  }

  deleteVilla(id: number): void {

  }

  //#region Privates

  private loadVillas(): void {

    this.villaSvc.getVillas().subscribe({
      next: (villasFromApi) => {
        this.villas = villasFromApi;
      },
      error: (e: HttpErrorResponse) => {
        console.log(`Error ${e}`);
      }
    });
  }

  //#endregion

}
