using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Application.Rents.ReserveRent
{
    internal sealed class ReserveRentCommandHandler
    (
        IUserRepository userRepository, 
        IVehicleRepository vehicleRepository, 
        IRentRepository rentRepository, 
        PriceService priceService, 
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    ) : ICommandHandler<ReserveRentCommand, Guid>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentRepository _rentRepository = rentRepository;
        private readonly PriceService _priceService = priceService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        public async Task<Result<Guid>> Handle(ReserveRentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if(user == null)
            {
                return Result.Failure<Guid>(UserError.Notfound);
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId,cancellationToken);

            if(vehicle == null)
            {
                return Result.Failure<Guid>(VehicleError.Notfound);
            }

            var duration = DateRange.Create(request.Begin, request.End);

            if(await _rentRepository.IsOverlappingAssing(vehicle, duration, cancellationToken))
            {
                return Result.Failure<Guid>(RentError.Overlap);
            }

            var rent = Rent.Reserve
            (
                vehicle,
                user.Id,
                duration, 
                _dateTimeProvider.CurrentTime,
                _priceService
            );

            _rentRepository.Add(rent);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(user.Id);
        }
    }
}