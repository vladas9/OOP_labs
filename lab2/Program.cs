void Task_2()
{
    Barista barista = new Barista();

    barista.MakeCoffee(Intensity.NORMAL);
    barista.MakeCappuccino(Intensity.STRONG, 150);
    barista.MakePumpkinSpiceLatte(Intensity.LIGHT, 200, 50);
    barista.MakeAmericano(Intensity.NORMAL, 250);
    barista.MakeSyrupCappuccino(Intensity.STRONG, 150, SyrupType.VANILLA);

    barista.PrintAllOrders();
}

Task_2();
