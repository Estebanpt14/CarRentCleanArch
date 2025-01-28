using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents
{
    public class PriceService
    {
        public PriceDetail CalculatePrice(Vehicle vehicle, DateRange period)
        {
            var typeCoin = vehicle.Price!.Type;

            var pricePerPeriod = new Coin(period.DayCount * vehicle.Price.Value, typeCoin);
            decimal percentaje = 0;

            foreach (var accesory in vehicle.Accesories)
            {
                percentaje += accesory switch
                {
                    Accesory.AndroidCar or Accesory.AppleCar => 0.05m,
                    Accesory.AirConditioner or Accesory.Maps => 0.01m,
                    _ => 0 
                };
            }
            
            var accesoryPrice = Coin.Zero(typeCoin);

            if(percentaje > 0)
            {
                accesoryPrice = new Coin(pricePerPeriod.Value * percentaje, typeCoin);
            }

            var total = accesoryPrice + pricePerPeriod + vehicle.Maintenance!;

            return new PriceDetail(pricePerPeriod, vehicle.Maintenance!, accesoryPrice, total);
        }
    }
}