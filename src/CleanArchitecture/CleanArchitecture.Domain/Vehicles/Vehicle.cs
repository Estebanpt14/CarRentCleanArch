using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehicles
{
    public sealed class Vehicle
        (
            Guid id,
            Model model,
            Vin vin,
            Coin price,
            Coin maintenance,
            DateTime? dateLastRent,
            Address? address,
            List<Accesory> accesories
        ) : Entity(id)
    {
        public List<Accesory> Accesories { get; private set; } = accesories;

        public Model? Model { get; private set; } = model;

        public Vin? Vin { get; private set; } = vin;

        public Address? Address { get; private set; } = address;

        public Coin? Price { get; private set; } = price;

        public Coin? Maintenance { get; private set; } = maintenance;

        public DateTime? DateLastRent { get; set; } = dateLastRent;
    }
}