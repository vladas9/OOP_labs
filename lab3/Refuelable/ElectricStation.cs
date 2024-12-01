public class ElectricStation : Refuelable
{
    private static int _electricCarsRefueledCount = 0;

    public void Refuel(string carId)
    {
        _electricCarsRefueledCount++;
        Console.WriteLine($"Refueling electric car {carId}.");
    }

    public static int GetElectricCarsRefueledCount() => _electricCarsRefueledCount;
}
