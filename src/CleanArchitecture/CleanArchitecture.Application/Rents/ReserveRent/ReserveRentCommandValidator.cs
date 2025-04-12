using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.Rents.ReserveRent
{
    public class ReserveRentCommandValidator : AbstractValidator<ReserveRentCommand>
    {
        public ReserveRentCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.VehicleId).NotEmpty();
            RuleFor(c => c.Begin).LessThan(c => c.End);
        }
        
    }
}