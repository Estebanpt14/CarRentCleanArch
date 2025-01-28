using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
    internal sealed class SearchVehiclesQueryHandler 
    (
        ISQLConnectionFactory sQLConnectionFactory
    ): IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
    {

        private readonly ISQLConnectionFactory _sqlConnectionFactory = sQLConnectionFactory; 

        public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(
            SearchVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            if(request.Begin > request.End)
            {
                return new List<VehicleResponse>();
            }

            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    v.id AS Id,
                    v.model AS Model,
                    v.vin AS Vin,
                    v.price AS Price,
                    v.type_coin AS TypeCoin,
                    v.address AS Address
                FROM vehicles AS v
                WHERE NOT EXISTS
                (
                    SELECT 1 FROM rents AS r
                    WHERE 
                        r.vehicle_id = v.id AND 
                        r.begin <= @EndDate AND
                        r.end >= @StartDate AND
                        r.status = ANY (@ActiveRentStatuses)
                )
            """;
        }
    }
}