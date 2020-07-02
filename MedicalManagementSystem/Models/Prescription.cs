using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public class Prescription
    {
        public long Id { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public decimal Price { get; set; }
        public Patient Patient { get; set; }
    }
}
