using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal abstract class Repository <T>(ApplicationDBContext dbContext) where T : Entity
    {
        protected readonly ApplicationDBContext _dbContext = dbContext;

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}