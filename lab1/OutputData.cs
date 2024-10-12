using System.Text.Json;

public class OutputData
{
    private string _univers = "";
    private List<Creature>? _output;

    public string univers
    {
        get => _univers;
        set => _univers = value;
    }

    public List<Creature>? input
    {
        get => _output;
        set => _output = value;
    }
}

public class JsonWriter
{

    public static void WriteJson(string univers, List<Creature> creatures)
    {
        string outputPath = $"output/{univers}.json";

        var outputData = new OutputData
        {
            univers = univers,
            input = creatures
        };

        string jsonString = JsonSerializer.Serialize(outputData, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(outputPath, jsonString);
    }
}
