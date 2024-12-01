public enum CarType
{
    ELECTRIC,
    GAS
}

public enum PassengerType
{
    PEOPLE,
    ROBOTS
}

public class Car
{
    public string Id { get; }
    public CarType Type { get; }
    public PassengerType Passengers { get; }
    public bool RequiresDining { get; }
    public int Consumption { get; }

    public Car(string id, CarType type, PassengerType passengers, bool requiresDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        RequiresDining = requiresDining;
        Consumption = consumption;
    }
}
