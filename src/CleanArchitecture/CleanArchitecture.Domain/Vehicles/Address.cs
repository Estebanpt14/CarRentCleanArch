using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Vehicles
{
    public record Address
    (
        string Country, 
        string State,
        string City,
        string Street
    );
}