using System.Text.Json;
using System.Text.Json.Serialization;

public enum CarType
{
    ELECTRIC,
    GAS
}

public enum PassengerType
{
    PEOPLE,
    ROBOTS
}


public class Car
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(CarTypeConverter))]
    public CarType Type { get; set; }

    [JsonPropertyName("passengers")]
    [JsonConverter(typeof(PassengerTypeConverter))]
    public PassengerType Passengers { get; set; }

    [JsonPropertyName("isDining")]
    public bool RequiresDining { get; set; }

    [JsonPropertyName("consumption")]
    public int Consumption { get; set; }


    public Car(int id, CarType type, PassengerType passengers, bool requiresDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        RequiresDining = requiresDining;
        Consumption = consumption;
    }

    public override string ToString()
    {
        return $"Car(Id: {Id}, Type: {Type}, Passengers: {Passengers}, RequiresDining: {RequiresDining}, Consumption: {Consumption})";
    }
}


public class CarTypeConverter : JsonConverter<CarType>
{
    public override CarType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value?.ToUpper() switch
        {
            "GAS" => CarType.GAS,
            "ELECTRIC" => CarType.ELECTRIC,
            _ => throw new JsonException($"Invalid value for CarType: {value}")
        };
    }

    public override void Write(Utf8JsonWriter writer, CarType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}



public class PassengerTypeConverter : JsonConverter<PassengerType>
{
    public override PassengerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value?.ToUpper() switch
        {
            "PEOPLE" => PassengerType.PEOPLE,
            "ROBOTS" => PassengerType.ROBOTS,
            _ => throw new JsonException($"Invalid value for PassengerType: {value}")
        };
    }

    public override void Write(Utf8JsonWriter writer, PassengerType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
