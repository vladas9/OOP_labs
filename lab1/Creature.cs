public class Creature
{
    private readonly int _id;
    private readonly bool? _isHumanoid;
    private readonly string? _planet;
    private readonly int? _age;
    private readonly List<string>? _traits;
    // private string _univers;

    public Creature(int id, bool? isHumanoid, string? planet, int? age, List<string>? traits)
    {
        _id = id;
        _isHumanoid = isHumanoid;
        _planet = planet;
        _age = age;
        _traits = traits;
        // _univers = "";
    }
    public int id => _id;
    public bool? isHumanoid => _isHumanoid;
    public string? planet => _planet;
    public int? age => _age;
    public List<string>? traits => _traits;
    // public string univers
    // {
    //     get => _univers;
    //     protected set => _univers = value;
    // }
}
