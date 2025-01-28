using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Shared
{
    public record CoinType
    {
        public static readonly CoinType None = new("");

        public static readonly CoinType Usd = new("USD");

        public static readonly CoinType Eur = new("EUR");

        private CoinType(string codigo) => Codigo = codigo; 

        public string? Codigo { get; init; }

        public static readonly IReadOnlyCollection<CoinType> All =
        [
            Usd,
            Eur
        ];

        public static CoinType FromCodigo(string codigo)
        {
            return All.FirstOrDefault(x => x.Codigo!.Equals(codigo)) ??
                throw new ApplicationException($"Could not find codigo {codigo}");
        }
    }   
}