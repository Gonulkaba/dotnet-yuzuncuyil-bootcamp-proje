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
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz.")
               .NotNull().WithMessage("Ad alanı null olamaz.")
               .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir. ");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş olamaz.")
              .NotNull().WithMessage("Soyad alanı null olamaz.")
               .MaximumLength(150).WithMessage("Soyad alanı en fazla 150 karakter olabilir. ");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş olamaz.")
              .NotNull().WithMessage("Adres alanı null olamaz.")
               .MaximumLength(150).WithMessage("Adres alanı en fazla 250 karakter olabilir. ");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş olamaz.")
              .NotNull().WithMessage("Telefon numarası alanı null olamaz.")
              .Length(10,15).WithMessage("Kullanıcı adı 10 ve 15 karakter arasında olmalıdır.")
              .Must(x => int.TryParse(x, out _)).WithMessage("Telefon numarası sadece sayılardan oluşmalıdır.");

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Bu alan boş olamaz.")
              .NotNull().WithMessage("Bu alan null olamaz.")
              .Must(id => id != 0)
               .WithMessage("Id alanı 0 olamaz");
        }
    }
}
