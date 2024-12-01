public class RobotDinner : Dineable
{
    private static int _robotsServedCount = 0;

    public void ServeDinner(string carId)
    {
        _robotsServedCount++;
        Console.WriteLine($"Serving dinner to robots in car {carId}.");
    }

    public static int GetRobotsServedCount() => _robotsServedCount;
}
