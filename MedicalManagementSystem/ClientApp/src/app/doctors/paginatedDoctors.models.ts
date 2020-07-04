import { Doctor } from "./doctors.models";

export interface PaginatedDoctors {
  currentPage: number;
  totalItems: number;
  itemsPerPage: number;
  totalPages: number;
  items: Doctor[];
}
