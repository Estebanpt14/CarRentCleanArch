using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class RentRepository(ApplicationDBContext dbContext)
        : Repository<Rent>(dbContext), IRentRepository
    {

        private readonly RentStatus[] _activeRentStatuses =
        [
            RentStatus.Reserved,
            RentStatus.Confirmed,
            RentStatus.Completed,
        ];

        public async Task<bool> IsOverlappingAssing(
            Vehicle vehicle, 
            DateRange duration, 
            CancellationToken cancellationToken = default
        )
        {
            return await _dbContext.Set<Rent>()
                .AnyAsync(
                    rent => rent.VehicleId == vehicle.Id &&
                    rent.Duration!.Begin <= duration.End &&
                    rent.Duration!.End >= duration.Begin && 
                    _activeRentStatuses.Contains(rent.RentStatus),
                    cancellationToken
                );
        }
    }
}