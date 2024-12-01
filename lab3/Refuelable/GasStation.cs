public class GasStation : Refuelable
{
    private static int _gasCarsRefueledCount = 0;

    public void Refuel(int carId)
    {
        _gasCarsRefueledCount++;
        Console.WriteLine($"Refueling gas car {carId}.");
    }

    public static int GetGasCarsRefueledCount() => _gasCarsRefueledCount;
}

