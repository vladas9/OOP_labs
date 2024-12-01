public class PeopleDinner : Dineable
{
    private static int _peopleServedCount = 0;

    public void ServeDinner(int carId)
    {
        _peopleServedCount++;
        Console.WriteLine($"Serving dinner to people in car {carId}.");
    }

    public static int GetPeopleServedCount() => _peopleServedCount;
}
