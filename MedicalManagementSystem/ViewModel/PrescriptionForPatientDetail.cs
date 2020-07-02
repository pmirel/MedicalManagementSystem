using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    public class PrescriptionForPatientDetail
    {
        public long Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public decimal Price { get; set; }
        public static PrescriptionForPatientDetail FromPrescripton(Prescription prescription)
        {
            return new PrescriptionForPatientDetail
            {
                Id = prescription.Id,
                Diagnosis = prescription.Diagnosis,
                DateAdded = prescription.DateAdded,
                Price = prescription.Price
            };
        }
    }
}
