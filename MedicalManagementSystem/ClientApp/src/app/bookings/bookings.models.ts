export interface Booking {
  id: number;
  location: string;
  dateOfBooking: Date;
  status: string;
  doctorId: number;
  patientId: number;
}
