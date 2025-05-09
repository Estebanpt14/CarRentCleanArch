using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions.Clock
{
    public interface IDateTimeProvider
    {
        DateTime CurrentTime { get; }
    }
}