public class Cappuccino : Coffee
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

    public override void make()
    {
        base.make();
        Console.WriteLine($"Adding {mlOfMilk}ml of milk to the Cappuccino.");
    }
}
