using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; init; }

        private readonly List<IDomainEvent> _domainEvents = [];

        protected Entity(Guid id)
        {
            Id = id;
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return [.. _domainEvents];
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}