public class PumpkinSpiceLatte : Coffee
{
    public int mlOfMilk { get; private set; }
    public int mgOfPumpkinSpice;
    public override string name => "PumpkinSpiceLatte";

    public PumpkinSpiceLatte(Intensity coffeeIntensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(coffeeIntensity)
    {
        this.mlOfMilk = mlOfMilk;
        this.mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} milk: {mlOfMilk} ml");
        Console.WriteLine($"{name} pumpkin spice: {mgOfPumpkinSpice} mg");
    }

    public override void make()
    {
        base.make();
        Console.WriteLine($"Adding {mlOfMilk}ml of milk and {mgOfPumpkinSpice}mg of pumpkin spice to the Pumpkin Spice Latte.");
    }
}
