using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Exceptions
{
    public sealed record ValidationError(string PropertyName, string ErrorMessage);
}