public class Americano : Coffee
{
    public int mlOfWater;
    const String name = "Americano";

    public Americano(Intensity coffeIntensity, int mlOfWater) : base(coffeIntensity)
    {
        this.mlOfWater = mlOfWater;
    }
}
