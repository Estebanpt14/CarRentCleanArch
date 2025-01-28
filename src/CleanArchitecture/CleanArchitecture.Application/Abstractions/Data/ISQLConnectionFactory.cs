using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions.Data
{
    public interface ISQLConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}