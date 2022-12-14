export interface BookingDetails {
  id: number;
  customerFullName: string;
  villaName: string;
  numberOfDays: number;
  numberOfOccupants: number;
  totalPrice: number;
  bookingStart: Date;
  bookingEnd: Date;
}
