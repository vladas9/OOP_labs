using System.Text.Json;

public record OutputData(string univers, List<Creature> output);


public class JsonWriter
{

    public static void WriteJson(string univers, List<Creature> creatures)
    {
        string outputPath = $"output/{univers}.json";

        var outputData = new OutputData(univers, creatures);

        string jsonString = JsonSerializer.Serialize(outputData, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(outputPath, jsonString);
    }
}
