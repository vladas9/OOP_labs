class Program
{
    private static Dictionary<string, List<Creature>> _classifiedCreatures = new(){
        {"Star Wars", new List<Creature>()},
        {"Marvel", new List<Creature>()},
        {"Hitchhiker's", new List<Creature>()},
        {"Lord of the Rings", new List<Creature>()}
    };
    static void Main(string[] args)
    {
        string filePath = "input.json";
        InputData? inputData = JsonReader.ReadJson(filePath);
        if (inputData?.input != null)
        {
            foreach (var creature in inputData.input)
            {
                (string univers, string race) = RaceCharacteristics.ClassifyCreature(creature);
                _classifiedCreatures[univers].Add(creature);
            }
            foreach (var element in _classifiedCreatures)
            {
                string univers = element.Key;
                List<Creature> creatures = element.Value;

                JsonWriter.WriteJson(univers, creatures);
            }
        }
        else
        {
            Console.WriteLine("No data found or error during deserialization.");
        }
    }
}
