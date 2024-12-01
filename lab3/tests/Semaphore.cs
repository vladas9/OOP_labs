using Moq;
using System.Text.Json;

[TestClass]
public class SemaphoreTests
{
    [TestMethod]
    public void TestSemaphoreRoutingAndServing()
    {
        var mockGasStation = new Mock<Refuelable>();
        var mockElectricStation = new Mock<Refuelable>();
        var mockDiningService = new Mock<Dineable>();

        var gasStationCarStation = new CarStation(mockDiningService.Object, mockDiningService.Object, mockGasStation.Object, new SimpleQueue<Car>());
        var electricStationCarStation = new CarStation(mockDiningService.Object, mockDiningService.Object, mockElectricStation.Object, new SimpleQueue<Car>());

        var semaphore = new Semaphore(gasStationCarStation, electricStationCarStation);

        string gasCarJson = JsonSerializer.Serialize(new Car(1, CarType.GAS, PassengerType.PEOPLE, false, 20));
        string electricCarJson = JsonSerializer.Serialize(new Car(2, CarType.ELECTRIC, PassengerType.ROBOTS, true, 30));

        semaphore.ProcessCarFromJson(gasCarJson);
        semaphore.ProcessCarFromJson(electricCarJson);
        semaphore.ServeAllCars();

        Assert.AreEqual(1, semaphore.GetGasCarsServed(), "Gas cars count is incorrect.");
        Assert.AreEqual(1, semaphore.GetElectricCarsServed(), "Electric cars count is incorrect.");

        mockGasStation.Verify(r => r.Refuel(1), Times.Once);
        mockElectricStation.Verify(r => r.Refuel(2), Times.Once);
    }

    [TestMethod]
    public void TestSemaphoreWithMultipleCars()
    {
        var mockGasStation = new Mock<Refuelable>();
        var mockElectricStation = new Mock<Refuelable>();
        var mockDiningService = new Mock<Dineable>();

        var gasStationCarStation = new CarStation(mockDiningService.Object, mockDiningService.Object, mockGasStation.Object, new SimpleQueue<Car>());
        var electricStationCarStation = new CarStation(mockDiningService.Object, mockDiningService.Object, mockElectricStation.Object, new SimpleQueue<Car>());

        var semaphore = new Semaphore(gasStationCarStation, electricStationCarStation);

        string gasCarJson1 = JsonSerializer.Serialize(new Car(1, CarType.GAS, PassengerType.PEOPLE, false, 20));
        string gasCarJson2 = JsonSerializer.Serialize(new Car(2, CarType.GAS, PassengerType.ROBOTS, true, 25));
        string electricCarJson1 = JsonSerializer.Serialize(new Car(3, CarType.ELECTRIC, PassengerType.ROBOTS, true, 30));
        string electricCarJson2 = JsonSerializer.Serialize(new Car(4, CarType.ELECTRIC, PassengerType.PEOPLE, false, 35));

        semaphore.ProcessCarFromJson(gasCarJson1);
        semaphore.ProcessCarFromJson(gasCarJson2);
        semaphore.ProcessCarFromJson(electricCarJson1);
        semaphore.ProcessCarFromJson(electricCarJson2);
        semaphore.ServeAllCars();

        Assert.AreEqual(2, semaphore.GetGasCarsServed(), "Gas cars count is incorrect.");
        Assert.AreEqual(2, semaphore.GetElectricCarsServed(), "Electric cars count is incorrect.");

        mockGasStation.Verify(r => r.Refuel(It.IsAny<int>()), Times.Exactly(2));
        mockElectricStation.Verify(r => r.Refuel(It.IsAny<int>()), Times.Exactly(2));
    }
}
