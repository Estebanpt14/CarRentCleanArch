using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents
{
    public static class RentError
    {
        public static readonly Error Notfound = new("Rent.NotFound", "The rent was not found");

        public static readonly Error Overlap = new("Rent.Overlap",
            "The rent is being taken by 2 o more cars on same date");

        public static readonly Error NotReserved = new("Rent.NotReserved", "The rent is not reserved");

        public static readonly Error NotConfirmed = new("Rent.NotConfirmed", "The rent is not confirmed");

        public static readonly Error AlreadyStarted = new("Rent.AlreadyStarted", "The rent has already started");
    }
}