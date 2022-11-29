import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogData } from '../models/deleteDialogData.model';
import { VillaList } from '../models/villas/villaList.model';
import { VillaService } from '../services/villa.service';
import { DeleteVillaComponent } from './dialogs/delete-villa/delete-villa.component';

@Component({
  selector: 'app-villa',
  templateUrl: './villa.component.html',
  styleUrls: ['./villa.component.css']
})
export class VillaComponent implements OnInit {

  villas: VillaList[] = [];
  showSpinner: boolean = true;

  constructor(
    private villaSvc: VillaService,
    public dialogSvc: MatDialog) { }

  ngOnInit(): void {

    this.loadVillas();
  }

  deleteVilla(id: number, name: string): void {

    const dialogRef = this.dialogSvc.open(DeleteVillaComponent, {
      data: {
        name: name
      } as DeleteDialogData
    });

    dialogRef.afterClosed().subscribe({

      next: (answer: Boolean) => {

        if (answer) {

          this.showSpinner = true;

          this.villaSvc.deleteVilla(id).subscribe({
            next: () => {
              this.loadVillas();
            },
            error: (e: HttpErrorResponse) => {
              alert(e.message);
              console.log(e);
            }
          });
        }
      }
    });
  }

  //#region Privates

  private loadVillas(): void {

    this.villaSvc.getVillas().subscribe({
      next: (villasFromApi) => {
        this.villas = villasFromApi;
        this.showSpinner = false;
      },
      error: (e: HttpErrorResponse) => {
        console.log(`Error ${e}`);
      }
    });
  }

  //#endregion

}
