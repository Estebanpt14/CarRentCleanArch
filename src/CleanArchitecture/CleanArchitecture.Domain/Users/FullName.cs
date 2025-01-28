using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Users
{
    public record FullName
    (
        string Name,
        string? MiddleName,
        string LastName,
        string? SecondName
    );
}