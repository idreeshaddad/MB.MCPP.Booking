import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.css']
})
export class UploaderComponent implements OnInit {

  progress!: number;
  message!: string;
  imageSrc: string = '../../../assets/imgs/user.png';

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
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

            this.message = 'Upload success.';
            this.onUploadFinished.emit(event.body);

            this.imageSrc = `${environment.imgStorageUrl}/${(event.body as any).imageName}`;
          }
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
  }

}
