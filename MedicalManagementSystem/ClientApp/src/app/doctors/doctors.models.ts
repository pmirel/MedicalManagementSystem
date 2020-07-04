export interface Doctor {
  id: number;
  firstName: string;
  lastName: string;
  speciality: Speciality;
}

export enum Speciality {
  Other = 0,
  Family = 1,
  Internal = 2,
  Neurology = 3,
  Emergency = 4,
  Dermatology = 5
}
