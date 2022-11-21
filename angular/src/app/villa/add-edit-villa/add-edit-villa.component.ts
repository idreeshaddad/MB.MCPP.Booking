import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { AddOn } from 'src/app/models/addon.model';
import { Villa } from 'src/app/models/villa.model';
import { VillaService } from 'src/app/services/villa.service';

@Component({
  selector: 'app-add-edit-villa',
  templateUrl: './add-edit-villa.component.html',
  styleUrls: ['./add-edit-villa.component.css']
})
export class AddEditVillaComponent implements OnInit {

  villaId?: number;
  villa?: Villa;
  villaForm!: FormGroup;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;
  addOns: string[] = [];

  villaNameExists: boolean = false;
  villaNameExistsMessage: string = 'Villa name already exists';

  constructor(
    private villaSvc: VillaService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setVillaId();
    this.setPageMode();

    this.buildForm();

    if (this.pageMode == PageMode.Edit) {

      this.loadVilla();
    }
  }

  submitForm(): void {

    if (this.villaForm.valid) {

      if (this.pageMode == PageMode.Create) {

        this.villaSvc.createVilla(this.villaForm.value).subscribe({

          next: () => {
            this.router.navigate(['/villas']);
          },
          error: (e: HttpErrorResponse) => {
            // TODO of villa name alreadu exists show validation msg
            // this.villaNameExists = true;
            console.log(`Error: ${e}`);
          }
        });
      }
      else {

        this.villaSvc.editVilla(this.villaId!, this.villaForm.value).subscribe({

          next: () => {
            this.router.navigate(['/villas']);
          },
          error: (e: HttpErrorResponse) => {

            console.log(`Error: ${e}`);
          }
        });
      }
    }
  }

  //#region Private

  private loadVilla() {

    this.villaSvc.getVilla(this.villaId!).subscribe({
      next: (villaFromApi) => {
        this.villa = villaFromApi;
        this.patchForm(villaFromApi);
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      }
    });
  }

  private setVillaId() {

    this.villaId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private setPageMode() {

    if (this.villaId) {

      this.pageMode = PageMode.Edit
    }
  }

  private buildForm() {

    this.villaForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      address: ['', Validators.required],
      rating: ['', Validators.required],
      numberOfOccupants: ['', Validators.required],
      price: ['', Validators.required],
      vacant: [0, Validators.required],
      // addOns: this.fb.array([
      //   this.fb.control('')
      // ])
    });
  }

  private patchForm(villa: Villa) {

    this.villaForm.patchValue({
      id: villa.id,
      name: villa.name,
      address: villa.address,
      rating: villa.rating,
      numberOfOccupants: villa.numberOfOccupants,
      price: villa.price,
      vacant: villa.vacant
      //addOns: AddOn[],
    });
  }

  //#endregion

}
