using RentalCars.Cars;

namespace RentalCars
{
    public class Rental
    {
        public Rental(Customer customer, Car car, int daysRented, Location location)
        {
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
            Location = location;

            if (car is LuxuryCar && customer.FrequentRenterPoints < 3)
            {
                throw new System.Exception("The customer " + customer.Name + "doesn't have enough loyalty points to rent a luxury car!");
            }
        }

        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }
        public Location Location { get; }

        public double calculateDiscount(double pricePerDay)
        {
            double discount = 0;
            if (Customer.FrequentRenterPoints >= 5 && !(Car is LuxuryCar))
            {
                discount = Car.calculateAmount(DaysRented, pricePerDay) * 0.5;
            }
            return discount;
        }
        public double calculateRentPrice(double pricePerDay)
        {
            return Car.calculateAmount(DaysRented, pricePerDay) - calculateDiscount(pricePerDay);
        }

        public void calculateFrequentRenterPoints()
        {
            Customer.FrequentRenterPoints++;
            if (Car is PremiumCar && DaysRented >= 2)
            {
                Customer.FrequentRenterPoints++;
            }
        }
    }
}