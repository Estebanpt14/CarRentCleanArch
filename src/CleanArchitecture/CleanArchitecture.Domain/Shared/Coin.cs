using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Shared
{
    public record Coin(decimal Value, CoinType Type)
    {
        public static Coin operator + (Coin first, Coin second)
        {
            if(first.Type != second.Type){
                throw new InvalidOperationException("The coin type must be the same");
            }

            return new Coin(first.Value + second.Value, first.Type);
        }

        public static Coin Zero() => new(0, CoinType.None);

        public static Coin Zero(CoinType coinType) => new(0, coinType);

        public bool IsZero => this == Zero(Type);
    }
}