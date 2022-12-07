import { Addon } from "../addon.model";

export interface Villa {
  id: number;
  name: string;
  address: string;
  rating: number;
  numberOfOccupants: number;
  price: number;
  isBooked: boolean;
  addonIds: number[];
}
