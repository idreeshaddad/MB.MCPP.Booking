import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DeleteDialogData } from 'src/app/models/deleteDialogData.model';

@Component({
  selector: 'app-delete-villa',
  templateUrl: './delete-villa.component.html',
  styleUrls: ['./delete-villa.component.css']
})
export class DeleteVillaComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: DeleteDialogData) { }

  ngOnInit(): void {
  }

}
