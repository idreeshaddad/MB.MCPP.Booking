import { Gender } from "../enums/gender.enum";

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  gender: Gender;
  dob: string;
  age: number;
  fullName: string;
  imageName: string;
}

