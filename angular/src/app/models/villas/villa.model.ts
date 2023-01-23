import { UploaderImage } from "src/app/directive/image-uploader/UploaderImage.data";

export class Villa {
  id: number = 0;
  name: string = "";
  address: string = "";
  rating: number = 0;
  numberOfOccupants: number = 0;
  price: number = 0;
  isBooked: boolean = false;
  addonIds: number[] = [];
  images: UploaderImage[] = [];

}
