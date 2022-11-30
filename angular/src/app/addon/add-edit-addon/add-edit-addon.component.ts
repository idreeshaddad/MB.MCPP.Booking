import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Addon } from 'src/app/models/addon.model';
import { AddonService } from 'src/app/services/addons.service';

@Component({
  selector: 'app-add-edit-addon',
  templateUrl: './add-edit-addon.component.html',
  styleUrls: ['./add-edit-addon.component.css']
})
export class AddEditAddonComponent implements OnInit {

  addonId?: number;
  addon?: Addon;
  addonForm!: FormGroup;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;

  constructor(
    private addonSvc: AddonService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.setAddonId();
    this.setPageMode();

    this.buildForm();

    if (this.pageMode == PageMode.Edit) {

      this.loadAddon();
    }
  }

  submitForm() {

    if (this.addonForm.valid) {

      if (this.pageMode == PageMode.Create) {

        this.addonSvc.createAddon(this.addonForm.value).subscribe({
          next: (addonFromApi) => {
            this.router.navigate(['/addons']);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err);
          }
        });
      }
      else {

        this.addonSvc.editAddon(this.addonId!, this.addonForm.value).subscribe({
          next: () => {
            this.router.navigate(['/addons']);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err.message);
          }
        });
      }
    }
  }

  //#region Private Methods

  private buildForm() {

    this.addonForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  private setAddonId(): void {

    this.addonId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private setPageMode(): void {

    if (this.addonId) {

      this.pageMode = PageMode.Edit
    }
  }

  private loadAddon() {

    this.addonSvc.getAddon(this.addonId!).subscribe({
      next: (addonFromApi) => {
        this.addon = addonFromApi;
        this.patchForm(addonFromApi);
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        alert(err);
      }
    });
  }

  private patchForm(addonFromApi: Addon) {

    this.addonForm.patchValue({
      id: addonFromApi.id,
      name: addonFromApi.name,
      price: addonFromApi.price,
    });
  }

  //#endregion

}
