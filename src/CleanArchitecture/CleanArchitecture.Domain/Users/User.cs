using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users.Events;

namespace CleanArchitecture.Domain.Users
{
    public sealed class User
        (
            Guid id,
            FullName fullName,
            Email email
        ) : Entity(id)
    {
        public FullName? FullName { get; private set; } = fullName;

        public Email? Email { get; private set; } = email;

        public static User Create
        (
            FullName fullName,
            Email email
        )
        {
            var user = new User(Guid.NewGuid(), fullName, email);
            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
            return new User(Guid.NewGuid(), fullName, email);
        }
    }
}