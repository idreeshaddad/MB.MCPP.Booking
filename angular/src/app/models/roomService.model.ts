import { Room } from "./room.model";

export interface RoomService {
  id: number;
  name: string;
  price: number;
  rooms: Room[];
}
