[TestClass]
public class DineableAndRefuelableTests
{
    [TestMethod]
    public void TestPeopleAndRobotsServed()
    {
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();

        peopleDinner.ServeDinner(1);
        peopleDinner.ServeDinner(2);
        robotDinner.ServeDinner(3);

        Assert.AreEqual(2, PeopleDinner.GetPeopleServedCount(), "Total people served count is incorrect.");
        Assert.AreEqual(1, RobotDinner.GetRobotsServedCount(), "Total robots served count is incorrect.");
    }

    [TestMethod]
    public void TestGasAndElectricCarsRefueled()
    {
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        gasStation.Refuel(1);
        gasStation.Refuel(2);
        electricStation.Refuel(3);

        Assert.AreEqual(2, GasStation.GetGasCarsRefueledCount(), "Total gas cars refueled count is incorrect.");
        Assert.AreEqual(1, ElectricStation.GetElectricCarsRefueledCount(), "Total electric cars refueled count is incorrect.");
    }

    [TestMethod]
    public void TestCarsThatSkipDining()
    {
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        gasStation.Refuel(1);
        electricStation.Refuel(2);

        Assert.AreEqual(3, GasStation.GetGasCarsRefueledCount(), "Total gas cars refueled count is incorrect after skipping dining.");
        Assert.AreEqual(2, ElectricStation.GetElectricCarsRefueledCount(), "Total electric cars refueled count is incorrect after skipping dining.");
    }
}
