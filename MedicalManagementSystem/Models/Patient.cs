using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<Prescription> Prescriptions { get; set; }

    }
}
