import { HttpClient, HttpEventType, HttpErrorResponse, HttpResponse, HttpEvent } from '@angular/common/http';
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

            this.onUploadFinished.emit(event.body);

            let imagesNames = this.getImagesNamesArray(event);

            this.imageSrc = `${environment.imgStorageUrl}/${imagesNames[0]}`;
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

  private getImagesNamesArray(event: HttpResponse<Object>): string[] {

    return (event.body as any).imagesNames as string[];
  }

  //#endregion

}
