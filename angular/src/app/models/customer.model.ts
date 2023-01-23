import { UploaderImage } from "../directive/image-uploader/UploaderImage.data";
import { Gender } from "../enums/gender.enum";

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  gender: Gender;
  dob: string;
  age: number;
  fullName: string;
  images: UploaderImage[];
  phoneNumber: string;
}

