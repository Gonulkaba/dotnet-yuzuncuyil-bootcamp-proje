using DotnetYuzuncuYilBootcamp.Core.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Validations
{
    public class DutyDtoValidator : AbstractValidator<DutyDto>
    {
        public DutyDtoValidator()
        {
            RuleFor(x => x.DutyName).NotNull().WithMessage("{PropertyName} null geçilemez.")
                .NotEmpty().WithMessage("{PropertyName} boş geçilemez")
                .MaximumLength(100).WithMessage("{PropertyName} en fazla 100 karakter olabilir. ");

            RuleFor(x => x.Description).NotNull().WithMessage("Description alanı null geçilemez.")
                .NotEmpty().WithMessage("Description alanı boş geçilemez")
                .MaximumLength(350).WithMessage("Description alanı en fazla 350 karakter olabilir. ");

            RuleFor(x => x.Status).NotNull().WithMessage("Status alanı null geçilemez.")
                .NotEmpty().WithMessage("Status alanı boş geçilemez")
                .MaximumLength(50).WithMessage("Status alanı en fazla 50 karakter olabilir. ");

            RuleFor(x => x.EmployeeId).NotNull().WithMessage("Bu alan null geçilemez.")
                .NotEmpty().WithMessage("Bu alan boş geçilemez")
                .Must(id => id != 0)
                .WithMessage("Id alanı 0 olamaz");

        }
    }
}
