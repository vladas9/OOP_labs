public class CarStation
{
    private readonly Dineable _peopleDiningService;
    private readonly Dineable _robotDiningService;
    private readonly Refuelable _refuelingService;
    private readonly IQueue<Car> _queue;

    public CarStation(Dineable peopleDiningService, Dineable robotDiningService, Refuelable refuelingService, IQueue<Car> queue)
    {
        _peopleDiningService = peopleDiningService;
        _robotDiningService = robotDiningService;
        _refuelingService = refuelingService;
        _queue = queue;
    }

    public void AddCar(Car car)
    {
        _queue.Enqueue(car);
    }

    public void ServeCars()
    {
        while (!_queue.IsEmpty())
        {
            Car car = _queue.Dequeue();

            if (car.RequiresDining)
            {
                if (car.Passengers == PassengerType.PEOPLE)
                {
                    _peopleDiningService.ServeDinner(car.Id);
                }
                else if (car.Passengers == PassengerType.ROBOTS)
                {
                    _robotDiningService.ServeDinner(car.Id);
                }
            }

            _refuelingService.Refuel(car.Id);
        }
    }
}
