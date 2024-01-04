using DotnetYuzuncuYilBootcamp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Validations
{
    public class EmployeeProfileDtoValidator : AbstractValidator<EmployeeProfileDto>
    {
        public EmployeeProfileDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kullanıcının adı boş olamaz.")
               .NotNull().WithMessage("Kullanıcının adı null olamaz.")
               .MaximumLength(150).WithMessage("Kullanıcının adı en fazla 150 karakter olabilir. ");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Kullanıcının soyadı boş olamaz.")
              .NotNull().WithMessage("Kullanıcının soyadı null olamaz.")
               .MaximumLength(150).WithMessage("Kullanıcının soyadı en fazla 150 karakter olabilir. ");
        }
    }
}
