namespace CoffeShop;
internal class SyrupCappuccino : Cappuccino
{
    public SyrupType syrup { get; private set; }
    public override string name => "SyrupCappuccino";
    public SyrupCappuccino(Intensity coffeeIntensity, int mlOfMilk, SyrupType syrup)
        : base(coffeeIntensity, mlOfMilk)
    {
        this.syrup = syrup;
    }

    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} syrup: {syrup} ml");
    }

    protected override void prepare()
    {
        base.prepare();
        Console.WriteLine($"Adding {syrup} of water to the Cappuccino.");
    }

    public SyrupCappuccino makeSyrupCappuccino()
    {
        prepare();
        return this;
    }
}
