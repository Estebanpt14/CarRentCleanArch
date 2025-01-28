using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents.Events;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents
{
    public sealed class Rent
    (
        Guid id,
        Guid vehicleId,
        Guid userId,
        RentStatus status,
        DateRange? duration,
        PriceDetail? priceDetail,
        DateTime creation,
        DateTime? confirmation,
        DateTime? completion,
        DateTime? cancelation,
        DateTime? denied
    ) : Entity(id)
    {
        public Guid VehicleId { get; private set; } = vehicleId;

        public Guid UserId { get; private set; } = userId;

        public PriceDetail? PriceDetail{ get; private set; } = priceDetail;

        public RentStatus RentStatus { get; private set; } = status;

        public DateRange? Duration { get; private set; } = duration;

        public DateTime? Creation { get; private set; } = creation;

        public DateTime? Confirmation { get; private set; } = confirmation;

        public DateTime? Completion { get; private set; } = completion;

        public DateTime? Denied { get; private set; } = denied;

        public DateTime? Cancelation { get; private set; } = cancelation;

        public static Rent Reserve
        (
            Vehicle vehicle,
            Guid userId,
            DateRange duration,
            DateTime creation,
            PriceService priceService
        )
        {
            var priceDetail = priceService.CalculatePrice(vehicle, duration);
            var rent = new Rent(Guid.NewGuid(), vehicle.Id, userId, RentStatus.Reserved, duration, priceDetail, 
                creation, null, null, null, null);

            rent.RaiseDomainEvent(new RentReservedDomainEvent(rent.Id));
            vehicle.DateLastRent = creation;

            return rent;
        }

        public Result Confirm(DateTime now)
        {
            if(RentStatus.Reserved != RentStatus)
            {
                return Result.Failure(RentError.NotReserved);
            }

            RentStatus = RentStatus.Confirmed;
            Confirmation = now;

            RaiseDomainEvent(new RentConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Deny(DateTime now)
        {
            if(RentStatus != RentStatus.Reserved)
            {
                return Result.Failure(RentError.NotReserved);
            }

            RentStatus = RentStatus.Denied;
            Denied = now;

            RaiseDomainEvent(new RentDeniedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime now)
        {
            if(RentStatus != RentStatus.Confirmed)
            {
                return Result.Failure(RentError.NotConfirmed);
            }

            if(DateOnly.FromDateTime(now) > Duration!.Begin)
            {
                return Result.Failure(RentError.AlreadyStarted);
            }

            RentStatus = RentStatus.Denied;
            Cancelation = now;

            RaiseDomainEvent(new RentDeniedDomainEvent(Id));

            return Result.Success();
        }

        public Result Completed(DateTime now)
        {
            if(RentStatus != RentStatus.Confirmed)
            {
                return Result.Failure(RentError.NotConfirmed);
            }

            RentStatus = RentStatus.Denied;
            Completion = now;

            RaiseDomainEvent(new RentCompletedDomainEvent(Id));

            return Result.Success();
        }

    }
}