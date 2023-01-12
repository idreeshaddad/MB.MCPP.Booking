import {
  HttpClient,
  HttpEventType,
  HttpErrorResponse,
} from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ImageUploaderConfig } from './image-uploader.config';
import { UploaderImage } from './UploaderImage.data';
import { UploaderMode, UploaderStyle, UploaderType } from './uploader.enums';

@Component({
  selector: 'app-image-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.css'],
})
export class ImageUploaderComponent implements OnInit {
  
  progress!: number;
  silhouetteImage!: string;

  uploaderStyleEnum = UploaderStyle;
  uploaderModeEnum = UploaderMode;
  uploaderTypeEnum = UploaderType;

  imagesNames: UploaderImage[] = [];

  @Output() public onUploadFinished = new EventEmitter();

  @Input() public config!: ImageUploaderConfig;
  @Input() public imagesNamesStrArr: string[] = [];

  slideConfig = { slidesToShow: 4, slidesToScroll: 4 };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    
    this.setSilhouetteImage();
  }

  uploadFile(files: FileList | null) {
    if (files === null) {
      return;
    }

    const formData = new FormData();

    for (let i = 0; i < files.length; i++) {
      formData.append('files', files[i]);
    }

    this.http
      .post(environment.uploadUrl, formData, {
        reportProgress: true,
        observe: 'events',
      })
      .subscribe({
        next: (event) => {
          if (event.type === HttpEventType.UploadProgress) {
            if (event.total == undefined) {
              event.total = 1;
              alert('event total is undefined');
            }
            this.progress = Math.round((100 * event.loaded) / event.total);
          } else if (event.type === HttpEventType.Response) {
            let uploaderImages = event.body as UploaderImage[];
            this.onUploadFinished.emit(uploaderImages);

            this.imagesNames = uploaderImages;
          }
        },
        error: (err: HttpErrorResponse) => console.log(err),
      });
  }

  getImageUrlFromUploaderImage(img: UploaderImage): string {
    return `${environment.imgStorageUrl}/${img.name}`;
  }

  getImageUrlFromString(imgName: string): string {
    return `${environment.imgStorageUrl}/${imgName}`;
  }

  //#region Private

  private setSilhouetteImage() {
    
    if (this.config.style == UploaderStyle.Normal) {
      this.silhouetteImage = '../../../assets/imgs/item.png';
    } else {
      this.silhouetteImage = '../../../assets/imgs/user.png';
    }
  }

  //#endregion
}
