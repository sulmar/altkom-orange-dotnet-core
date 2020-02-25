using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{

    // dotnet add package FluentValidation
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Login).NotEmpty().Length(3, 50);
        }
    }
}
