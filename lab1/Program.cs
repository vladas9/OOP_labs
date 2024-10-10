class Program
{
    static void Main(string[] args)
    {
        string filePath = "input.json";
        InputData? inputData = JsonReader.ReadJson(filePath);
        if (inputData?.input != null)
        {
            foreach (var creature in inputData.input)
            {
                Console.WriteLine($"ID: {creature.id}");
                Console.WriteLine($"Is Humanoid: {creature.isHumanoid}");
                Console.WriteLine($"Planet: {creature.planet}");
                Console.WriteLine($"Age: {creature.age}");
                Console.WriteLine("Traits: " + (creature.traits != null ? string.Join(", ", creature.traits) : "None"));
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No data found or error during deserialization.");
        }
    }
}
