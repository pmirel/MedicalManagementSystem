using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public class Prescription
    {
        public long Id { get; set; }
        public long Diagnosis { get; set; }
        public long Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public decimal Price { get; set; }
        public Patient Patient { get; set; }
        public Doctor AddedBy { get; set; }
    }
}
