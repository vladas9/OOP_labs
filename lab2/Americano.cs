public class Americano : Coffee
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

    public override void make()
    {
        base.make();
        Console.WriteLine($"Adding {mlOfWater}ml of water to the Cappuccino.");
    }
}
