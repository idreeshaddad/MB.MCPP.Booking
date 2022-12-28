import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ImageUploaderConfig } from './image-uploader.config';
import { UploaderMode } from './uploaderMode.enum';

@Component({
  selector: 'app-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.css']
})
export class ImageUploaderComponent implements OnInit {

  progress!: number;
  imageSrc!: string;
  uploaderModeEnum = UploaderMode;

  @Output() public onUploadFinished = new EventEmitter();

  @Input() public config: ImageUploaderConfig = {
    mode: UploaderMode.Normal
  };

  constructor(private http: HttpClient) { }

  ngOnInit() {

    this.setSilhouetteImage();
  }

  uploadFile(files: any) {

    if (files.length === 0) {
      return;
    }

    let fileToUpload = files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

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

            this.onUploadFinished.emit(event.body);

            this.imageSrc = `${environment.imgStorageUrl}/${(event.body as any).imageName}`;
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
