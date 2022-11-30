import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Addon } from 'src/app/models/addon.model';
import { AddonService } from 'src/app/services/addons.service';

@Component({
  selector: 'app-addon-details',
  templateUrl: './addon-details.component.html',
  styleUrls: ['./addon-details.component.css']
})
export class AddonDetailsComponent implements OnInit {

  addonId!: number;
  addon!: Addon;

  constructor(
    private addonSvc: AddonService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.loadAddon();
  }

  private loadAddon() {

    this.addonId = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    if (this.addonId) {

      this.addonSvc.getAddon(this.addonId).subscribe({
        next: (addonFromApi) => {
          this.addon = addonFromApi;
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      });
    }

  }
}
