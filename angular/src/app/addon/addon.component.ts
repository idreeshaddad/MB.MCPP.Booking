import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Addon } from '../models/addon.model';
import { DeleteDialogData } from '../models/deleteDialogData.model';
import { AddonService } from '../services/addons.service';
import { DeleteAddonComponent } from './dialogs/delete-addon/delete-addon.component';

@Component({
  selector: 'app-addon',
  templateUrl: './addon.component.html',
  styleUrls: ['./addon.component.css']
})
export class AddonComponent implements OnInit {

  addons!: Addon[];
  showSpinner: boolean = true;

  constructor(
    private addonSvc: AddonService,
    private dialogSvc: MatDialog
  ) { }

  ngOnInit(): void {

    this.loadAddons();
  }

  deleteAddon(id: number, name: string): void {

    const dialogRef = this.dialogSvc.open(DeleteAddonComponent, {
      data: {
        name: name
      } as DeleteDialogData,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe({

      next: (answer: Boolean) => {

        if (answer) {

          this.showSpinner = true;

          this.addonSvc.deleteAddon(id).subscribe({
            next: () => {
              this.loadAddons();
            },
            error: (err: HttpErrorResponse) => {
              alert(err.message);
              console.log(err);
            }
          });
        }
      }
    });
  }

  private loadAddons(): void {

    this.addonSvc.getAddons().subscribe({
      next: (addonsFromApi) => {
        this.addons = addonsFromApi;
        this.showSpinner = false;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        alert(err.message);
      }
    });
  }

}
