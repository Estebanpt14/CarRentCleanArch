using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public record Error(string Code, string Text)
    {
        public static Error None = new(string.Empty, string.Empty);

        public static Error Null = new("Error.Null", "A null value was found");
    }
}