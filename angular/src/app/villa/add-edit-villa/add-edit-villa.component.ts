import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageUploaderConfig } from 'src/app/directive/image-uploader/image-uploader.config';
import { UploaderImage } from 'src/app/directive/image-uploader/UploaderImage.data';
import { UploaderMode } from 'src/app/directive/image-uploader/uploaderMode.enum';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Lookup } from 'src/app/models/lookup.model';
import { Villa } from 'src/app/models/villas/villa.model';
import { AddonService } from 'src/app/services/addons.service';
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
  addonsLookup: Lookup[] = [];

  villaNameExists: boolean = false;
  villaNameExistsMessage: string = 'Villa name already exists';

  uploaderConfig = new ImageUploaderConfig(UploaderMode.Normal, true);

  constructor(
    private villaSvc: VillaService,
    private addonSvc: AddonService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setVillaId();
    this.setPageMode();

    this.buildForm();

    this.loadAddonsLookup();

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
            console.log(e.error);
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

  uploadFinished(uploaderImages: UploaderImage[]) {
    
    this.villaForm.patchValue({
      villaImages: uploaderImages
    })
  }

  //#region Private

  private loadVilla() {

    this.villaSvc.getEditVilla(this.villaId!).subscribe({
      next: (villaFromApi) => {
        this.villa = villaFromApi;
        this.villaForm.patchValue(villaFromApi);
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
      isBooked: [false, Validators.required],
      addonIds: [[]],
      villaImages: []
    });
  }

  private loadAddonsLookup(): void {

    this.addonSvc.getAddonLookup().subscribe({
      next: (addonLookupFromApi) => {
        this.addonsLookup = addonLookupFromApi;
      }
    });
  }

  // Obseleted(Not used anymore): for educational purposes only!
  // private patchForm(villa: Villa) {

  //   this.villaForm.patchValue({
  //     id: villa.id,
  //     name: villa.name,
  //     address: villa.address,
  //     rating: villa.rating,
  //     numberOfOccupants: villa.numberOfOccupants,
  //     price: villa.price,
  //     isBooked: villa.isBooked,
  //     addonIds: villa.addons.map(({ id }) => id)
  //   });
  // }

  //#endregion

}
