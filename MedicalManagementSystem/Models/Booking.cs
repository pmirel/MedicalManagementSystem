using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateOfBooking { get; set; }
        public string Status { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public long PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
