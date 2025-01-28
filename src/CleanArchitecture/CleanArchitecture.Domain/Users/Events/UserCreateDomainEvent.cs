using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(Guid Id) : IDomainEvent;
}