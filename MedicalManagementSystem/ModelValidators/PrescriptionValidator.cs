using FluentValidation;
using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ModelValidators
{
    public class PrescriptionValidator : AbstractValidator<Prescription>
    {
        public PrescriptionValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Diagnosis)
                .Length(2, 20)
                .WithMessage("Text must have minimum 2 characters and maximum 20.");
            RuleFor(x => x.Diagnosis)
                .NotEmpty()
                .WithMessage("Diagnosis cannot be empty.");
            RuleFor(x => x.DateAdded)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Date must be equal or higer tha today");
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be equal or higher than 0");
        }
    }
}
