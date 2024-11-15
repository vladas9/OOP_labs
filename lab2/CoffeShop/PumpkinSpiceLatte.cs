namespace CoffeShop;

internal class PumpkinSpiceLatte : Cappuccino
{
    public int mgOfPumpkinSpice;
    public override string name => "PumpkinSpiceLatte";

    public PumpkinSpiceLatte(Intensity coffeeIntensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(coffeeIntensity, mlOfMilk)
    {
        this.mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} milk: {mlOfMilk} ml");
        Console.WriteLine($"{name} pumpkin spice: {mgOfPumpkinSpice} mg");
    }

    protected override void prepare()
    {
        base.prepare();
        Console.WriteLine($"Adding {mgOfPumpkinSpice}mg of pumpkin spice to the {name}.");
    }

    public PumpkinSpiceLatte makePumpkinSpiceLatte()
    {
        prepare();
        return this;
    }
}
