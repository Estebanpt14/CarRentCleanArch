using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents
{
    public interface IRentRepository
    {
        Task<Rent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAssing(Vehicle vehicle, DateRange duration, 
            CancellationToken cancellationToken = default);
        
        void Add(Rent rent);
    }
}