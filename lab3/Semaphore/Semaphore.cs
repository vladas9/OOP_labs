using System.Text.Json;

public class Semaphore
{
    private readonly CarStation _gasStationCarStation;
    private readonly CarStation _electricStationCarStation;

    private int _gasCarsServed = 0;
    private int _electricCarsServed = 0;

    public Semaphore(CarStation gasStationCarStation, CarStation electricStationCarStation)
    {
        _gasStationCarStation = gasStationCarStation;
        _electricStationCarStation = electricStationCarStation;
    }


    public void ProcessCarFromJson(string json)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var car = JsonSerializer.Deserialize<Car>(json, options);

            if (car == null)
            {
                Console.WriteLine("Failed to deserialize car. JSON: " + json);
                return;
            }


            if (car.Type == CarType.GAS)
            {
                _gasStationCarStation.AddCar(car);
                _gasCarsServed++;
            }
            else if (car.Type == CarType.ELECTRIC)
            {
                _electricStationCarStation.AddCar(car);
                _electricCarsServed++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing JSON: {json}. Exception: {ex.Message}");
        }
    }


    public void ServeAllCars()
    {
        _gasStationCarStation.ServeCars();
        _electricStationCarStation.ServeCars();
    }

    public int GetGasCarsServed() => _gasCarsServed;
    public int GetElectricCarsServed() => _electricCarsServed;
}
