using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public enum Speciality
    {
        Other = 0,
        Family = 1,
        Internal = 2,
        Neurology = 3,
        Emergency = 4,
        Dermatology = 5
    }
    public class Doctor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Speciality Speciality { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
