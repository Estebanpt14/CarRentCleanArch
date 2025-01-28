using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
    public sealed record SearchVehiclesQuery(DateOnly Begin, DateOnly End) 
        : IQuery<IReadOnlyList<VehicleResponse>>;
}