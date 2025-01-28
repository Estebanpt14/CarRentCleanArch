using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Messaging
{
    public interface ICommandHandler<T> : IRequestHandler<T, Result> where T : ICommand
    {
        
    }

    public interface ICommandHandler<T, R> : IRequestHandler<T, Result<R>> where T : ICommand<R>
    {
        
    }
}