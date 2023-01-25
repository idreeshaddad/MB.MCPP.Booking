import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageUploaderConfig } from 'src/app/directive/image-uploader/image-uploader.config';
import { UploaderMode, UploaderStyle, UploaderType } from 'src/app/directive/image-uploader/uploader.enums';
import { UploaderImage } from 'src/app/directive/image-uploader/UploaderImage.data';
import { Villa } from 'src/app/models/villas/villa.model';
import { VillaDetails } from 'src/app/models/villas/villaDetails.model';
import { VillaService } from 'src/app/services/villa.service';

@Component({
  selector: 'app-villa-details',
  templateUrl: './villa-details.component.html',
  styleUrls: ['./villa-details.component.css']
})
export class VillaDetailsComponent implements OnInit {

  villaId!: number;
  villa!: VillaDetails;

  images: UploaderImage[] = [];

  uploaderConfig = new ImageUploaderConfig(UploaderStyle.Normal, UploaderMode.Details, UploaderType.Multiple);
  
  constructor(
    private villaSvc: VillaService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {

    this.loadVilla();
  }

  loadVilla() {

    this.villaId = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    if (this.villaId) {

      this.villaSvc.getVilla(this.villaId).subscribe({
        next: (villaFromApi: VillaDetails) => {
          this.villa = villaFromApi;

          if(villaFromApi.images) {
            this.images = villaFromApi.images;
          }
        },
        error: (e: HttpErrorResponse) => {
          console.log(e.message);
          this.router.navigate(['/not-found']);
        }
      });
    }
  }

}
