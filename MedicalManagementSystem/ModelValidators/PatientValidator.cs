using FluentValidation;
using MedicalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ModelValidators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName)
                .Length(2, 10)
                .WithMessage("Text must have minimum 2 characters and maximum 10.");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Text cannot be empty.");
            RuleFor(x => x.LastName)
                .Length(2, 10)
                .WithMessage("Text must have minimum 2 characters and maximum 10.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Text cannot be empty.");
            RuleFor(x => x.CNP)
                .Length(13)
                .WithMessage("CNP must have 13 numbers");
        }
    }
    
}
