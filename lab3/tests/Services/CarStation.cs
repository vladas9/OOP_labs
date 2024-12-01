using Moq;

[TestClass]
public class CarStationTests
{
    [TestMethod]
    public void TestServeCarsWithDiningAndRefueling()
    {
        var mockDiningService = new Mock<Dineable>();
        var mockRefuelingService = new Mock<Refuelable>();
        var queue = new SimpleQueue<Car>();

        var carStation = new CarStation(mockDiningService.Object, mockRefuelingService.Object, queue);

        var car1 = new Car("Car1", CarType.ELECTRIC, PassengerType.PEOPLE, true, 30);
        var car2 = new Car("Car2", CarType.GAS, PassengerType.ROBOTS, false, 20);
        var car3 = new Car("Car3", CarType.GAS, PassengerType.PEOPLE, true, 40);

        carStation.AddCar(car1);
        carStation.AddCar(car2);
        carStation.AddCar(car3);

        carStation.ServeCars();

        mockDiningService.Verify(d => d.ServeDinner("Car1"), Times.Once);
        mockDiningService.Verify(d => d.ServeDinner("Car3"), Times.Once);
        mockDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Exactly(2));

        mockRefuelingService.Verify(r => r.Refuel("Car1"), Times.Once);
        mockRefuelingService.Verify(r => r.Refuel("Car2"), Times.Once);
        mockRefuelingService.Verify(r => r.Refuel("Car3"), Times.Once);
        mockRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(3));

        Assert.IsTrue(queue.IsEmpty(), "Queue should be empty after serving all cars.");
    }

    [TestMethod]
    public void TestServeCarsWithNoDining()
    {
        var mockDiningService = new Mock<Dineable>();
        var mockRefuelingService = new Mock<Refuelable>();
        var queue = new SimpleQueue<Car>();

        var carStation = new CarStation(mockDiningService.Object, mockRefuelingService.Object, queue);

        var car1 = new Car("Car1", CarType.GAS, PassengerType.PEOPLE, false, 25);
        var car2 = new Car("Car2", CarType.ELECTRIC, PassengerType.ROBOTS, false, 35);

        carStation.AddCar(car1);
        carStation.AddCar(car2);

        carStation.ServeCars();

        mockDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Never);
        mockRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(2));

        Assert.IsTrue(queue.IsEmpty(), "Queue should be empty after serving all cars.");
    }

    [TestMethod]
    public void TestServeCarsWithEmptyQueue()
    {
        var mockDiningService = new Mock<Dineable>();
        var mockRefuelingService = new Mock<Refuelable>();
        var queue = new SimpleQueue<Car>();

        var carStation = new CarStation(mockDiningService.Object, mockRefuelingService.Object, queue);

        carStation.ServeCars();

        mockDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Never);
        mockRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Never);
        Assert.IsTrue(queue.IsEmpty(), "Queue should remain empty.");
    }

}
