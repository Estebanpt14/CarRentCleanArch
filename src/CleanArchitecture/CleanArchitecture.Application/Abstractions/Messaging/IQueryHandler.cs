using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, T> : IRequestHandler<TQuery, Result<T>> where TQuery :IQuery<T>
    {
        
    }
}