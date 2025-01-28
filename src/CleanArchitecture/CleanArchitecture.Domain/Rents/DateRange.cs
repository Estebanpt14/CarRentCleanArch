using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Rents
{
    public sealed record DateRange
    {
        private DateRange()
        {
            
        }

        public DateOnly Begin { get; private set; }

        public DateOnly End { get; private set; }

        public int DayCount => End.DayNumber - Begin.DayNumber;

        public static DateRange Create(DateOnly begin, DateOnly end)
        {
            if(begin > end)
            {
                throw new ApplicationException("Begin date must by lower than end date");
            }
            
            return new DateRange{Begin  = begin, End = end};
        }
    }
}