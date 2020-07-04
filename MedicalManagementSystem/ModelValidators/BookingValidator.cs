using FluentValidation;
using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ModelValidators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.DateOfBooking)
                .GreaterThan(DateTime.Now)
                .WithMessage("Date must be greather yhan now");
        }
    }
}
