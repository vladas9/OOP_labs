namespace CoffeShop;

public enum CoffeeType
{
    COFFEE,
    AMERICANO,
    CAPPUCCINO,
    SYRUP_CAPPUCCINO,
    PUMPKIN_SPICE_LATTE,
}

public class Barista
{
    private readonly List<Coffee> coffeeOrders = new List<Coffee>();

    public void makeCoffe(CoffeeType type, Intensity intensity = Intensity.NORMAL, int mlOfWater = 50, int mlOfMilk = 50, SyrupType syrup = SyrupType.CARAMEL, int mgOfPumpkinSpice = 30)
    {
        switch (type)
        {
            case CoffeeType.COFFEE:
                var coffee = new Coffee(intensity);
                coffee.makeCoffe();
                coffeeOrders.Add(coffee);
                break;

            case CoffeeType.AMERICANO:
                var americano = new Americano(intensity, mlOfWater);
                americano.makeAmericano();
                coffeeOrders.Add(americano);
                break;

            case CoffeeType.CAPPUCCINO:
                var cappuccino = new Cappuccino(intensity, mlOfMilk);
                cappuccino.makeCappucino();
                coffeeOrders.Add(cappuccino);
                break;

            case CoffeeType.SYRUP_CAPPUCCINO:
                var syrupCappuccino = new SyrupCappuccino(intensity, mlOfMilk, syrup);
                syrupCappuccino.makeSyrupCappuccino();
                coffeeOrders.Add(syrupCappuccino);
                break;

            case CoffeeType.PUMPKIN_SPICE_LATTE:
                var pumpkinSpiceLatte = new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice);
                pumpkinSpiceLatte.makePumpkinSpiceLatte();
                coffeeOrders.Add(pumpkinSpiceLatte);
                break;

            default:
                Console.WriteLine("Unknown coffee type!");
                break;
        }
    }


    public void PrintAllOrders()
    {
        foreach (var coffee in coffeeOrders)
        {
            coffee.printCoffeeDetails();
        }
    }
}
