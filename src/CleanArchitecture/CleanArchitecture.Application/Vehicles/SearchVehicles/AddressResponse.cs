using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
    public sealed class AddressResponse
    {
        public string? Country { get; init; }

        public string? State { get; init; }

        public string? City { get; init; }

        public string? Street { get; init; }
    }
}