public class Wookie : Creature
{
    public Wookie(Creature creature) :
      base(creature.id, false, "Kashyyk", creature.age, ["HAIRY", "TALL"])
    { }
}

public class Ewok : Creature
{
    public Ewok(Creature creature) :
      base(creature.id, false, "Endor", creature.age, ["SHORT", "HAIRY"])
    { }
}

public class Asgardian : Creature
{
    public Asgardian(Creature creature) :
      base(creature.id, true, "Asgard", creature.age, ["BLONDE", "TALL"])
    { }
}

public class Betelgeusian : Creature
{
    public Betelgeusian(Creature creature) :
        base(creature.id, true, "BETELGEUSE", creature.age, ["EXTRA_ARMS", "EXTRA_HEAD"])
    { }
}

public class Vogons : Creature
{
    public Vogons(Creature creature) :
        base(creature.id, false, "Vogsphere", creature.age, ["GREEN", "BULKY"])
    { }
}

public class Elf : Creature
{
    public Elf(Creature creature) :
        base(creature.id, true, "Earth", creature.age, ["BLONDE", "POINTY_EARS"])
    { }
}

public class Dwarf : Creature
{
    public Dwarf(Creature creature) :
        base(creature.id, true, "Earth", creature.age, ["SHORT", "BULKY"])
    { }
}
