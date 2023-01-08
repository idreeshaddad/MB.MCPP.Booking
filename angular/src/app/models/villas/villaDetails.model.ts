import { Addon } from "../addon.model";

export interface VillaDetails {
  id: number;
  name: string;
  address: string;
  rating: number;
  numberOfOccupants: number;
  price: number;
  isBooked: boolean;
  addons: Addon[];
  villaImages: string[];
}
