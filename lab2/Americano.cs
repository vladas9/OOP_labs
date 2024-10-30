public class Americano : Coffee
{
    public int mlOfWater { get; private set; }
    const String name = "Americano";

    public Americano(Intensity coffeIntensity, int mlOfWater) : base(coffeIntensity)
    {
        this.mlOfWater = mlOfWater;
    }

    public override void printCoffeeDetails()
    {
        base.printCoffeeDetails();
        Console.WriteLine($"{name} water: {mlOfWater} ml");
    }
}
