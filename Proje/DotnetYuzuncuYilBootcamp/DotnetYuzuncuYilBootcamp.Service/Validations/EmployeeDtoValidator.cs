using DotnetYuzuncuYilBootcamp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Validations
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .NotNull().WithMessage("Kullanıcı adı null olamaz!")
                .Length(1, 50).WithMessage("Kullanıcı adı 3 ve 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .NotNull().WithMessage("Email null olamaz.")
                .EmailAddress().WithMessage("Geçeri bir e-posta adresi giriniz.");

            RuleFor(x => x.Position).NotEmpty().WithMessage("Position alanı boş olamaz.")
                .NotNull().WithMessage("Position alanı null olamaz!")
                .MaximumLength(150).WithMessage("Position alanı en fazla 150 karakter olabilir. ");
        }
    }
}
