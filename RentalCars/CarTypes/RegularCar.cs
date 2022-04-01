using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Cars
{
    public class RegularCar : Car
    {
        private const int NUMBER_OF_DAYS_WITH_STANDARD_PRICE = 2;
        public RegularCar(string model) : base(model)
        {
        }

        public override double calculateAmount(int daysRented, double pricePerDay)
        {
            return NUMBER_OF_DAYS_WITH_STANDARD_PRICE * pricePerDay + (daysRented - NUMBER_OF_DAYS_WITH_STANDARD_PRICE) * pricePerDay * 0.75;
        }
    }
}
