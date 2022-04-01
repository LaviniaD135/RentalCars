using RentalCars.Cars;
using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalCars store1 = new RentalCars("Iasi Rentals");
            RentalCars store2 = new RentalCars("Bucharest Rentals");
            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali", 10);

            store2.AddRental(new Rental(customer1, new RegularCar("Dacia Logan"), 2, Location.Bucharest));
            store1.AddRental(new Rental(customer2, new RegularCar("Renault Clio"), 2, Location.Iasi));
            store2.AddRental(new Rental(customer1, new PremiumCar("BMW 330i"), 5, Location.Bucharest));
            store1.AddRental(new Rental(customer2, new PremiumCar("Volvo XC90"), 7, Location.Iasi));
            store1.AddRental(new Rental(customer3, new MiniCar("Toyota Aygo"), 2, Location.Iasi));
            store2.AddRental(new Rental(customer2, new RegularCar("Hyundai i10"), 2, Location.Bucharest));
            store2.AddRental(new Rental(customer1, new RegularCar("Hyundai i10"), 2, Location.Bucharest));
            store2.AddRental(new Rental(customer2, new RegularCar("Hyundai i10"), 2, Location.Bucharest));
            store2.AddRental(new Rental(customer3, new LuxuryCar("Merc G-Class"), 10, Location.Bucharest));
            store2.AddRental(new Rental(customer3, new MiniCar("Toyota Aygo"), 2, Location.Iasi));
            store2.AddRental(new Rental(customer3, new MiniCar("Toyota Aygo"), 2, Location.Iasi));

            Console.WriteLine(store1.Statement());
            Console.WriteLine();
            Console.WriteLine(store1.Statement());
            Console.WriteLine();
            Console.WriteLine(store2.StatementGroupedByCarCategory());
            Console.WriteLine();
            Console.WriteLine(store1.StatementGroupedByCarCategory());
            Console.ReadKey();

        }
    }
}
