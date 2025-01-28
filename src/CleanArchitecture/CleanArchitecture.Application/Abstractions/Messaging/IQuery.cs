using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Application.Abstractions.Messaging
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
        
    }
}