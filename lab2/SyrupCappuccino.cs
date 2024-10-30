public class SyrupCappuccino : Cappuccino
{
    public SyrupType syrup { get; private set; }
    const String name = "SyrupCappuccino";
    public SyrupCappuccino(Intensity coffeeIntensity, int mlOfMilk, SyrupType syrup)
        : base(coffeeIntensity, mlOfMilk)
    {
        this.syrup = syrup;
    }
}
