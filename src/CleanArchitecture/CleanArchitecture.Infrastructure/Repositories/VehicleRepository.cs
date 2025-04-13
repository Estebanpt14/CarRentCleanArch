using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class VehicleRepository(ApplicationDBContext dbContext) 
        : Repository<Vehicle>(dbContext), IVehicleRepository
    {

    }
}