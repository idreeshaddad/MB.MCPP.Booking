import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
        next: (villaFromApi) => {
          this.villa = villaFromApi;
        },
        error: (e: HttpErrorResponse) => {
          console.log(e.message);
          this.router.navigate(['/not-found']);
        }
      });
    }
  }

}
