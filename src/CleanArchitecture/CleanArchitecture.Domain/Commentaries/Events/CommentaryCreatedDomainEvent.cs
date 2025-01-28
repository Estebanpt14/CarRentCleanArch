using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Commentaries.Events
{
    public sealed record CommentaryCreatedDomainEvent(Guid id) : IDomainEvent;
}