using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehicles
{
    public class VehicleError
    {
        public static readonly Error Notfound = new("User.NotFound", "The vehicle was not found");
    }
}