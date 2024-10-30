public class Cappuccino : Coffee
{
    public int mlOfMilk { get; private set; }
    const String name = "Cappuccino";
    public Cappuccino(Intensity coffeeIntensity, int mlOfMilk) : base(coffeeIntensity)
    {
        this.mlOfMilk = mlOfMilk;
    }
}
