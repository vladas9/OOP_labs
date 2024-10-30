public class Barista
{
    private readonly List<Coffee> coffeeOrders = new List<Coffee>();

    public void MakeCoffee(Intensity intensity)
    {
        var coffee = new Coffee(intensity);
        coffeeOrders.Add(coffee);
        coffee.make();
    }

    public void MakeCappuccino(Intensity intensity, int mlOfMilk)
    {
        var cappuccino = new Cappuccino(intensity, mlOfMilk);
        coffeeOrders.Add(cappuccino);
        cappuccino.make();
    }

    public void MakePumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
    {
        var pumpkinSpiceLatte = new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice);
        coffeeOrders.Add(pumpkinSpiceLatte);
        pumpkinSpiceLatte.make();
    }

    public void MakeAmericano(Intensity intensity, int mlOfWater)
    {
        var americano = new Americano(intensity, mlOfWater);
        coffeeOrders.Add(americano);
        americano.make();
    }

    public void MakeSyrupCappuccino(Intensity intensity, int mltrOfMilk, SyrupType syrup)
    {
        var syrupCappuccino = new SyrupCappuccino(intensity, mltrOfMilk, syrup);
        coffeeOrders.Add(syrupCappuccino);
        syrupCappuccino.make();
    }

    public void PrintAllOrders()
    {
        foreach (var coffee in coffeeOrders)
        {
            coffee.printCoffeeDetails();
        }
    }
}