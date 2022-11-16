import { RoomService } from "./roomService.model";

export interface Room {
  id: number;
  name: string;
  address: string;
  rating: number;
  numberOfOccupants: number;
  price: number;
  occupied: boolean;
  services: RoomService[];
}
