import { HttpClient, HttpEventType, HttpErrorResponse, HttpResponse, HttpEvent } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ImageUploaderConfig } from './image-uploader.config';
import { UploaderImage } from './UploaderImage.data';
import { UploaderMode } from './uploaderMode.enum';

@Component({
  selector: 'app-image-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.css']
})
export class ImageUploaderComponent implements OnInit {

  progress!: number;
  imageSrc!: string;
  uploaderModeEnum = UploaderMode;

  @Output() public onUploadFinished = new EventEmitter();

  @Input() public config!: ImageUploaderConfig;

  constructor(private http: HttpClient) { }

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

    this.http.post(environment.uploadUrl, formData, { reportProgress: true, observe: 'events' })
      .subscribe({
        next: (event) => {
          if (event.type === HttpEventType.UploadProgress) {
            if (event.total == undefined) {
              event.total = 1;
              alert("event total is undefined");
            }
            this.progress = Math.round(100 * event.loaded / event.total);
          }
          else if (event.type === HttpEventType.Response) {

            let uploaderImages = event.body as UploaderImage[];
            this.onUploadFinished.emit(uploaderImages);

            this.imageSrc = `${environment.imgStorageUrl}/${uploaderImages[0].name}`;
          }
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
  }

  //#region Private

  private setSilhouetteImage() {

    if (this.config.mode == UploaderMode.Normal) {
      this.imageSrc = '../../../assets/imgs/item.png';
    }
    else {
      this.imageSrc = '../../../assets/imgs/user.png';
    }
  }

  //#endregion

}
