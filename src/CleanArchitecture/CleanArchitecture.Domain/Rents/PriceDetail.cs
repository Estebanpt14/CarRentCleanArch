using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Rents
{
    public record PriceDetail
    (
        Coin PricePerPeriod,
        Coin Maintenance,
        Coin Accesories,
        Coin Total
    );
}