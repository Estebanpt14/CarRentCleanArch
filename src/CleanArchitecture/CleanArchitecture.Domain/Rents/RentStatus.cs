using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Rents
{
    public enum RentStatus
    {
       Reserved = 1,
       Confirmed = 2,
       Denied = 3,
       Cancelled = 4, 
       Completed = 5
    }
}