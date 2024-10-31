using CoffeShop;

var barista = new Barista();

barista.makeCoffe(CoffeeType.COFFEE, Intensity.LIGHT);
barista.makeCoffe(CoffeeType.AMERICANO, Intensity.NORMAL, 100);
barista.makeCoffe(CoffeeType.CAPPUCCINO, Intensity.STRONG, mlOfMilk: 150);
barista.makeCoffe(CoffeeType.SYRUP_CAPPUCCINO, Intensity.NORMAL, mlOfMilk: 100, syrup: SyrupType.VANILLA);
barista.makeCoffe(CoffeeType.PUMPKIN_SPICE_LATTE, Intensity.STRONG, mlOfMilk: 200, mgOfPumpkinSpice: 50);

// Print all orders
Console.WriteLine("\nAll Coffee Orders:");
barista.PrintAllOrders();
