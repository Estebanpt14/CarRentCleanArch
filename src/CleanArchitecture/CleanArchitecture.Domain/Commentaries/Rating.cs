using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Commentaries
{
    public sealed record Rating
    {
        private Rating(int value) => Value = value;

        public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

        public int Value { get; init; }

        public static Result<Rating> Create(int value)
        {
            if(value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}