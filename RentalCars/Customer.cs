using System.Collections.Generic;

namespace RentalCars
{
    public class Customer
    {
        public string Name { get; }

        public int FrequentRenterPoints { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
        public Customer(string name, int frequentRenterPoints)
        {
            Name = name;
            FrequentRenterPoints = frequentRenterPoints;
        }

        public List<Rental> Rentals { get; } = new List<Rental>();

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}