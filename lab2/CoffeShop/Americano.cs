namespace CoffeShop;

internal class Americano : Coffee
{
    public int mlOfWater { get; private set; }
    public override string name => "Americano";

    public Americano(Intensity coffeIntensity, int mlOfWater) : base(coffeIntensity)
    {
        this.mlOfWater = mlOfWater;
    }

    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} water: {mlOfWater} ml");
    }

    protected override void prepare()
    {
        base.prepare();

        Console.WriteLine($"Adding {mlOfWater}ml of water to the {name}");
    }

    public Americano makeAmericano()
    {
        prepare();
        return this;
    }
}
