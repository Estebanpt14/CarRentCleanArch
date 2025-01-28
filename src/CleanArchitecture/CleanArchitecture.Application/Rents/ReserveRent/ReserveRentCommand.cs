using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Rents.ReserveRent
{
    public record ReserveRentCommand
    (
        Guid VehicleId,
        Guid UserId,
        DateOnly Begin,
        DateOnly End
    ) : ICommand<Guid>;
}