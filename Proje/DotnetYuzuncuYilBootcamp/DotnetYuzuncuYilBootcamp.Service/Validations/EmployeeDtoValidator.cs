using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Validations
{
    public class EmployeeDtoValidator : AbstractValidator<AuthRequestDto>
    {
        public EmployeeDtoValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .NotNull().WithMessage("Kullanıcı adı null olamaz!")
                .Length(3, 50).WithMessage("Kullanıcı adı 3 ve 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .NotNull().WithMessage("Email null olamaz.")
                .EmailAddress().WithMessage("Geçeri bir e-posta adresi giriniz.");

            RuleFor(x => x.Position).NotEmpty().WithMessage("Bu alan boş olamaz.")
                .NotNull().WithMessage("Bu alan null olamaz!")
                .MaximumLength(150).WithMessage("Bu alan en fazla 150 karakter olabilir. ");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.")
                .NotNull().WithMessage("Şifre null olamaz!")
                .Length(5, 50).WithMessage("Şifre en az 5, en fazla 50 karakter arasında olmalıdır.");
        }
    }
}
