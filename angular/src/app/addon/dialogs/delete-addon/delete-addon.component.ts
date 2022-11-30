import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DeleteDialogData } from 'src/app/models/deleteDialogData.model';

@Component({
  selector: 'app-delete-addon',
  templateUrl: './delete-addon.component.html',
  styleUrls: ['./delete-addon.component.css']
})
export class DeleteAddonComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: DeleteDialogData) { }

  ngOnInit(): void {


  }

}
