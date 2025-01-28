using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users
{
    public class UserError
    {
        public static readonly Error Notfound = new("User.NotFound", "The user was not found");

        public static readonly Error InvalidCredentials = new("User.InvalidCredentials", 
            "The credentials are incorrect");
    }
}