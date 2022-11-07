import { Gender } from "../enums/gender.enum";

export interface Customer {
  id: number;
  name: string;
  gender: Gender;
  dob: string;
  age: number;
}

