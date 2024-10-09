public record InputData(List<Creature> Input);

public record Creature(int Id, bool? IsHumanoid, string Planet, int? Age, List<string> Traits);
