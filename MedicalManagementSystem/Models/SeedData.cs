using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MMSDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MMSDbContext>>()))
            {
                // Look for any doctors.
                if (context.Doctors.Any())
                {
                    return;   // DB has been seeded
                }

                context.Doctors.AddRange(
                    new Doctor
                    {
                        FirstName = "Ion",
                        LastName = "Ionescu",
                        Speciality = Speciality.Family
                    },
                    new Doctor
                    {
                        FirstName = "Miriam",
                        LastName = "John",
                        Speciality = Speciality.Dermatology
                    },
                    new Doctor
                    {
                        FirstName = "Ella",
                        LastName = "Smith",
                        Speciality = Speciality.Emergency
                    },
                    new Doctor
                    {
                        FirstName = "Carl",
                        LastName = "James",
                        Speciality = Speciality.Neurology
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
