using RentalCars.Cars;

namespace RentalCars
{
    public class Rental
    {
        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }
        public Location Location { get; }

        public Rental(Customer customer, Car car, int daysRented, Location location)
        {
            if (car is LuxuryCar && customer.FrequentRenterPoints < 3)
            {
                throw new System.Exception("The customer " + customer.Name + "doesn't have enough loyalty points to rent a luxury car!");
            }

            Customer = customer;
            Car = car;
            DaysRented = daysRented;
            Location = location;

            calculateFrequentRenterPoints();
        }

        public double calculateRentalPrice(double pricePerDay)
        {
            var rentalPrice = Car.calculateAmount(DaysRented, pricePerDay);
            if (Customer.FrequentRenterPoints >= 5 && !(Car is LuxuryCar))
            {
                return rentalPrice * 0.95;
            }

            return rentalPrice;
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