using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Exceptions
{
    public sealed class ValidationException(IEnumerable<ValidationError> errors) : Exception
    {
        public IEnumerable<ValidationError> Errors { get; } = errors;
    }
}