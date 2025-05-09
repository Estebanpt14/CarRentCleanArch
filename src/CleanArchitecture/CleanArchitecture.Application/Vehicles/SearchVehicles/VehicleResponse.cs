using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
    public sealed class VehicleResponse
    {
        public Guid Id { get; init; }

        public string? Model { get; init; }

        public string? Vin { get; init; }

        public decimal Price { get; init; }

        public string? TypeCoin { get; init; }

        public AddressResponse? Address { get; set; }

    }
}