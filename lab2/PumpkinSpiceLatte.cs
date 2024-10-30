public class PumpkinSpiceLatte : Coffee
{
    public int mlOfMilk { get; private set; }
    public int mgOfPumpkinSpice;
    const String name = "PumpkinSpiceLatte";

    public PumpkinSpiceLatte(Intensity coffeeIntensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(coffeeIntensity)
    {
        this.mlOfMilk = mlOfMilk;
        this.mgOfPumpkinSpice = mgOfPumpkinSpice;
    }
}
