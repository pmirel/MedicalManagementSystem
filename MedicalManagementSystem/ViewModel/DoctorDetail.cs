using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    public class DoctorDetail
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Speciality Speciality { get; set; }
        public List<PatientForDoctorDetail> Patients { get; set; }

        public static DoctorDetail FromDoctor(Doctor doctor)
        {
            return new DoctorDetail
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Speciality = doctor.Speciality,
                Patients = doctor.Patients.Select(c => PatientForDoctorDetail.FromPatient(c)).ToList()
            };
        }
    }
}
