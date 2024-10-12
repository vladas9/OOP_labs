using System.Text.Json;

public class InputData
{
    private List<Creature>? _input;

    public List<Creature>? input
    {
        get => _input;
        set => _input = value;
    }
}

public class JsonReader
{
    public static InputData? ReadJson(string filePath)
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            InputData? inputData = JsonSerializer.Deserialize<InputData>(jsonString);
            return inputData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}
