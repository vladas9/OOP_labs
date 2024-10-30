public class Coffee
{
    public Intensity coffeeIntensity { get; private set; }
    public virtual string name => "Coffe";

    public Coffee(Intensity coffeeIntensity)
    {
        this.coffeeIntensity = coffeeIntensity;
    }

    public virtual void printCoffeeDetails()
    {
        Console.WriteLine($"\n{name} Intensity: {coffeeIntensity}");
    }


    public virtual void make()
    {
        Console.WriteLine($"\nMaking a {name}");
        Console.WriteLine($"Set Intensity to {coffeeIntensity}");
    }
}
