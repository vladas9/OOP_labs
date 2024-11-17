using CoffeShop;

namespace MyCoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var barista = new Barista();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nWelcome to the Coffee Shop!");
                Console.WriteLine("Please select a coffee type to make:");

                foreach (var type in Enum.GetValues(typeof(CoffeeType)))
                {
                    Console.WriteLine($"{(int)type}. {type}");
                }
                Console.WriteLine($"{((int)Enum.GetValues(typeof(CoffeeType)).Length + 1)}. Exit");

                Console.Write("Enter your choice: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the coffee type.");
                    continue;
                }

                if (choice == Enum.GetValues(typeof(CoffeeType)).Length + 1)
                {
                    exit = true;
                    break;
                }

                if (!Enum.IsDefined(typeof(CoffeeType), choice))
                {
                    Console.WriteLine("Invalid choice. Please select a valid coffee type.");
                    continue;
                }

                CoffeeType selectedType = (CoffeeType)choice;

                MakeCoffeeWithDefaults(barista, selectedType);
            }

            Console.WriteLine("\nAll Coffee Orders:");
            barista.PrintAllOrders();
        }

        static void MakeCoffeeWithDefaults(Barista barista, CoffeeType type)
        {
            switch (type)
            {
                case CoffeeType.COFFEE:
                    barista.makeCoffe(type, Intensity.LIGHT);
                    break;
                case CoffeeType.AMERICANO:
                    barista.makeCoffe(type, Intensity.NORMAL, 100);
                    break;
                case CoffeeType.CAPPUCCINO:
                    barista.makeCoffe(type, Intensity.STRONG, mlOfMilk: 150);
                    break;
                case CoffeeType.SYRUP_CAPPUCCINO:
                    barista.makeCoffe(type, Intensity.NORMAL, mlOfMilk: 100, syrup: SyrupType.VANILLA);
                    break;
                case CoffeeType.PUMPKIN_SPICE_LATTE:
                    barista.makeCoffe(type, Intensity.STRONG, mlOfMilk: 200, mgOfPumpkinSpice: 50);
                    break;
                default:
                    Console.WriteLine("Unknown coffee type selected.");
                    break;
            }

            Console.WriteLine($"{type} has been prepared.");
        }
    }
}

