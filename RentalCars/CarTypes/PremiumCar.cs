using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Cars
{
    public class PremiumCar : Car
    {
        public PremiumCar(string model) : base(model)
        {
        }

        public override double calculateAmount(int daysRented, double pricePerDay)
        {
            return daysRented * pricePerDay * 1.5;
        }

    }
}
