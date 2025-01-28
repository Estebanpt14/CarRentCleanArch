using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Rents.GetRent
{
    public sealed class RentResponse
    {
        public Guid Id { get; init; }

        public Guid GuidId { get; init; }

        public Guid VehicleId { get; init; }

        public int Status { get; init; }

        public decimal RentPrice { get; init; }

        public string? RentTypeCoin { get; init; }

        public decimal MaintenancePrice { get; init; }

        public string? MaintenanceTypeCoin { get; init; }

        public decimal AccesoriesPrice { get; init; }

        public string? AccesoriesTypeCoin { get; init; }

        public decimal Totalrice { get; init; }

        public string? TotalTypeCoin { get; init; }

        public DateOnly Begin { get; init; }

        public DateOnly End { get; init; }

        public DateTime Creation { get; init; }

    }
}