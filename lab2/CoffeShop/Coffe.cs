namespace CoffeShop;

internal class Coffee
{
    public Intensity coffeeIntensity { get; private set; }
    public virtual string name => "Coffee";

    public Coffee(Intensity coffeeIntensity)
    {
        this.coffeeIntensity = coffeeIntensity;
    }

    public virtual void printCoffeeDetails()
    {
        Console.WriteLine($"\n{name} Intensity: {coffeeIntensity}");
    }

    protected virtual void prepare()
    {
        Console.WriteLine($"\nMaking a {name}");
        Console.WriteLine($"Set Intensity to {coffeeIntensity}");
    }

    public Coffee makeCoffe()
    {
        prepare();
        return this;
    }
}
