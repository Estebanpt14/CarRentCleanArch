using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Rents.GetRent
{
    public sealed record GetRentQuery(Guid RentId) : IQuery<RentResponse>;
}