using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Commentaries.Events;
using CleanArchitecture.Domain.Rents;

namespace CleanArchitecture.Domain.Commentaries
{
    public sealed class Commentary
    (
        Guid id,
        Guid vehicleId,
        Guid userId,
        Guid rentId,
        Rating rating, 
        string? value,
        DateTime creation
    ) : Entity(id)
    {

        public Guid VehicleId { get; private set; } = vehicleId;

        public Guid RentId { get; private set; } = rentId;

        public Guid UserId { get; private set; } = userId;

        public Rating Rating { get; private set; } = rating;

        public string? Value { get; private set; } = value;

        public DateTime Creation { get; private set; } = creation;

        public static Result<Commentary> Create
        (
            Rent rent,
            Rating rating,
            string? value,
            DateTime creation
        )
        {
            if(rent.RentStatus != RentStatus.Completed)
            {
                return Result.Failure<Commentary>(CommentaryError.NotCompleted);
            }

            var commentary = new Commentary(Guid.NewGuid(), rent.VehicleId, rent.UserId, rent.Id,
                rating, value, creation);

            commentary.RaiseDomainEvent(new CommentaryCreatedDomainEvent(commentary.Id));

            return commentary;
        }
    }
}