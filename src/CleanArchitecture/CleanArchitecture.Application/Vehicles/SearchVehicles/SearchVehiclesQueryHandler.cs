using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Rents;
using Dapper;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
    internal sealed class SearchVehiclesQueryHandler 
    (
        ISQLConnectionFactory sQLConnectionFactory
    ): IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
    {

        private static readonly int[] ActiveRentStatuses = 
        [
            (int)RentStatus.Reserved,
            (int)RentStatus.Confirmed,
            (int)RentStatus.Completed
        ];

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
                    v.address_country AS Country,
                    v.address_state AS State,
                    v.address_city AS City,
                    v.address_street AS Street
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

            var vehicles = await connection.QueryAsync<VehicleResponse, AddressResponse, VehicleResponse>
            (
                sql,
                (vehicle, address) => {
                    vehicle.Address = address;
                    return vehicle;
                },
                new 
                {
                    StartDate = request.Begin,
                    EndDate = request.End,
                    ActiveRentStatuses
                },
                splitOn: "Country"
            );

            return vehicles.ToList();
        }
    }
}