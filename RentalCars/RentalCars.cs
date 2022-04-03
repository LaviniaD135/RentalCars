using RentalCars.Cars;
using System.Collections.Generic;
using System.Linq;

namespace RentalCars
{
    public class RentalCars
    {
        private const string RENTAL_RECORD_FOR = "Rental Record for ";
        private const string BORDER = "----------------------------------------------\n";
        private const string EURO = " EUR";
        private const string DAYS = " days";
        private const int PRICE_PER_DAY_IN_BUCHAREST = 30;
        private const int PRICE_PER_DAY_IN_IASI = 20;
        private const string TOTAL_REVENUE = "Total revenue ";

        private readonly List<Rental> _rentals = new List<Rental>();
        public RentalCars(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
        }
        public string Statement()
        {
            double totalAmount = 0;
            var rentalRecord = RENTAL_RECORD_FOR + Name + "\n";
            rentalRecord += BORDER;

            foreach (Rental rental in _rentals)
            {
                double thisAmount = CalculateFinalAmount(rental);
                rentalRecord += rental.Customer.Name + "\t" + rental.Car.Model + "\t" + rental.DaysRented + DAYS + "\t"  + thisAmount + EURO + "\n";
                totalAmount += thisAmount;
            }
            rentalRecord += BORDER;
            rentalRecord += TOTAL_REVENUE + totalAmount + EURO;

            return rentalRecord;
            
        }

        private static double CalculateFinalAmount(Rental rental)
        {
            double thisAmount = 0;
            switch (rental.Location)
            {
                case Location.Iasi:
                    thisAmount += rental.calculateRentalPrice(PRICE_PER_DAY_IN_IASI);
                    break;

                case Location.Bucharest:
                    thisAmount += rental.calculateRentalPrice(PRICE_PER_DAY_IN_BUCHAREST);
                    break;
            }

            return thisAmount;
        }

        public string StatementGroupedByCarCategory()
        {
            var groupedRentals = _rentals.GroupBy(rental => rental.Car.GetType().Name);
            var rentalRecord = RENTAL_RECORD_FOR + Name + "\n";
            rentalRecord += BORDER;
            double totalAmount = 0;


            foreach (var group in groupedRentals)
            {
                double sum = 0;
                foreach (Rental rental in group)
                {
                    double thisAmount = CalculateFinalAmount(rental);

                    sum += thisAmount;

                }
                rentalRecord += group.Key + "\t" + sum + EURO + "\n";
                rentalRecord += BORDER;
                totalAmount += sum;
            }


            rentalRecord += TOTAL_REVENUE + totalAmount + EURO;

            return rentalRecord;

        }
    }
}