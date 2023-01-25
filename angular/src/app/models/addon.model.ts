import { UploaderImage } from "../directive/image-uploader/UploaderImage.data";

export interface Addon {
  id: number;
  name: string;
  price: number;
  images: UploaderImage[];
}
