using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    public class PatientForDoctorDetail
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        
        public static PatientForDoctorDetail FromPatient(Patient patient)
        {
            return new PatientForDoctorDetail
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                CNP = patient.CNP
            };
        }
    }
}
