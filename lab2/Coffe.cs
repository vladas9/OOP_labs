public class Coffee
{
    public Intensity coffeeIntensity { get; private set; }
    const String name = "Coffe";

    public Coffee(Intensity coffeeIntensity)
    {
        this.coffeeIntensity = coffeeIntensity;
    }
}
