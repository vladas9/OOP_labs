public class CarStation
{
    private readonly Dineable _diningService;
    private readonly Refuelable _refuelingService;
    private readonly IQueue<Car> _queue;

    public CarStation(Dineable diningService, Refuelable refuelingService, IQueue<Car> queue)
    {
        _diningService = diningService;
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
                _diningService.ServeDinner(car.Id);
            }

            _refuelingService.Refuel(car.Id);
        }
    }
}
