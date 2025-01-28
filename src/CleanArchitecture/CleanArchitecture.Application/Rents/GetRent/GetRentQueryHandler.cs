using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using Dapper;

namespace CleanArchitecture.Application.Rents.GetRent
{
    internal sealed class GetRentQueryHandler
    (
        ISQLConnectionFactory sQLConnectionFactory
    ) : IQueryHandler<GetRentQuery, RentResponse>
    
    {

        private readonly ISQLConnectionFactory _sqlConnectionFactory = sQLConnectionFactory;

        public async Task<Result<RentResponse>> Handle(GetRentQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.CreateConnection();
            var sql = """
                SELECT
                    id AS Id,            
                    vehicle_id AS VehicleId,
                    user_id AS UserId,
                    status AS Status,
                    rent_price AS PriceRent,
                    rent_type_coin AS PriceTypeCoin,
                    maintenance_price AS MaintenancePrice,
                    maintenance_type_coin AS MaintenanceTypeCoin,
                    accesories_price AS AccesoriesPrice,
                    accesories_type_coin AS AccesoriesTypeCoin,
                    total_price AS TotalPrice,
                    total_type_coin AS TotalTypeCoin,
                    begin AS Begin,
                    end AS End,
                    creation AS Creation
                FROM rents WHERE id=@RentId
            """;

            var rent = await connection.QueryFirstOrDefaultAsync<RentResponse>
            (
                sql,
                new {
                    request.RentId
                }
            );

            return rent!;
        }
    }
}