public record Creature(int id, bool? isHumanoid, string? planet, int? age, List<string>? traits)
{
    private string? _race;
    public string? race { get => _race; set => _race = value; }
};
