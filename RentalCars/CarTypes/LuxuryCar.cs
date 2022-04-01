using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Cars
{
    public class LuxuryCar : Car
    {
        public LuxuryCar(string model) : base(model)
        {
        }

        public override double calculateAmount(int daysRented, double pricePerDay)
        {
            return daysRented * pricePerDay * 7 / 3;
        }
    }
}
