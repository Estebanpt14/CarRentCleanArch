using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Domain.Rents.Events
{
    public sealed record RentCancelledDomainEvent(Guid Id) : IDomainEvent;
}