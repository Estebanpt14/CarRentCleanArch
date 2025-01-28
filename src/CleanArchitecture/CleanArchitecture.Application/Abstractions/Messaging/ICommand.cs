using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
        
    }

    public interface ICommand<T> : IRequest<Result<T>>, IBaseCommand
    {
        
    }

    public interface IBaseCommand
    {
        
    }
}