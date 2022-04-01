namespace RentalCars
{
    public abstract class Car
    {
        public Car(string model)
        {

            Model = model;
        }
        public string Model { get; }
        public abstract double calculateAmount(int daysRented, double pricePerDay);
    }
}