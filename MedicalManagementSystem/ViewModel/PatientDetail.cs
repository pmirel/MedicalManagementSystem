using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    public class PatientDetail
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public List<PrescriptionForPatientDetail> Prescriptions { get; set; }

        public static PatientDetail FromPatient(Patient patient)
        {
            return new PatientDetail
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                CNP = patient.CNP,
                Adress = patient.Adress,
                Email = patient.Email,
                Prescriptions = patient.Prescriptions.Select(c => PrescriptionForPatientDetail.FromPrescripton(c)).ToList()
            };
        }
    }
}
