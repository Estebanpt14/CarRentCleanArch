using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Data;
using Npgsql;

namespace CleanArchitecture.Infrastructure.Data
{
    internal sealed class SQLConnectionFactory(string connectionString) : ISQLConnectionFactory
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}