using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Commentaries
{
    public static class CommentaryError
    {
        public static readonly Error NotCompleted = new("Commentary.NotCompleted", "The rent is not completed");
        
    }
}