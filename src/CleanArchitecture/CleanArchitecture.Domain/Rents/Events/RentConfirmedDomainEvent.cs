using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events
{
    public sealed record RentConfirmedDomainEvent(Guid Id) : IDomainEvent;
}