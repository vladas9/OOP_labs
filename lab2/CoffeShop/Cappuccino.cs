namespace CoffeShop;

internal class Cappuccino : Coffee
{
    public int mlOfMilk { get; private set; }
    public override string name => "Cappuccino";

    public Cappuccino(Intensity coffeeIntensity, int mlOfMilk) : base(coffeeIntensity)
    {
        this.mlOfMilk = mlOfMilk;
    }
    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} milk: {mlOfMilk} ml");
    }

    protected override void prepare()
    {
        base.prepare();
        Console.WriteLine($"Adding {mlOfMilk}ml of milk to the {name}.");
    }

    public Cappuccino makeCappucino()
    {
        prepare();
        return this;
    }
}
