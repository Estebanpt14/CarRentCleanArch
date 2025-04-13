using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class UserRepository(ApplicationDBContext dbContext) 
        : Repository<User>(dbContext), IUserRepository
    {
        
    }
}