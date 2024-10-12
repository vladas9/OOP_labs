public static class RaceCharacteristics
{
    private static readonly Dictionary<string, Func<Creature, bool>> _raceChecks = new()
    {
        { "Unknown", creature => creature.isHumanoid == null &&
                                 creature.planet == null &&
                                 (creature.age == null || creature.age <= 5000) &&
                                 creature.traits ==null},
        // Star Wars Universe: Wookie
        { "Wookie", creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                                (creature.planet == null || creature.planet == "Kashyyyk") &&
                                (creature.age == null || (creature.age >= 0 && creature.age <= 400)) &&
                                (creature.traits == null ||
                                creature.traits.Contains("HAIRY") ||
                                creature.traits.Contains("TALL")) },

        // Star Wars Universe: Ewok
        { "Ewok", creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                              (creature.planet == null || creature.planet == "Endor") &&
                              (creature.age == null || (creature.age >= 0 && creature.age <= 60)) &&
                              (creature.traits == null ||
                              creature.traits.Contains("SHORT") ||
                              creature.traits.Contains("HAIRY")) },

        // Marvel Universe: Asgardian
        { "Asgardian", creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                  (creature.planet == null || creature.planet == "Asgard") &&
                                  (creature.age == null || (creature.age >= 0 && creature.age <= 5000)) &&
                                  (creature.traits == null ||
                                    creature.traits.Contains("BLONDE") ||
                                    creature.traits.Contains("TALL")) },

        // Hitchhiker's Universe: Betelgeusian
        { "Betelgeusian", creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                      (creature.planet == null || creature.planet == "Betelgeuse") &&
                                      (creature.age == null || (creature.age >= 0 && creature.age <= 100)) &&
                                      (creature.traits == null ||
                                      creature.traits.Contains("EXTRA_ARMS") ||
                                      creature.traits.Contains("EXTRA_HEAD")) },

        // Hitchhiker's Universe: Vogon
        { "Vogon", creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                              (creature.planet == null || creature.planet == "Vogsphere") &&
                              (creature.age == null || (creature.age >= 0 && creature.age <= 200)) &&
                              (creature.traits == null ||
                                creature.traits.Contains("GREEN") ||
                                creature.traits.Contains("BULKY")) },

      

        // Lord of the Rings Universe: Dwarf
        { "Dwarf", creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                              (creature.planet == null || creature.planet == "Earth") &&
                              (creature.age == null || (creature.age >= 0 && creature.age <= 200)) &&
                              (creature.traits == null ||
                                creature.traits.Contains("SHORT") ||
                                creature.traits.Contains("BULKY")) },

        // Lord of the Rings Universe: Elf
        { "Elf", creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                            (creature.planet == null || creature.planet == "Earth") &&
                            (creature.traits == null ||
                              creature.traits.Contains("BLONDE") ||
                              creature.traits.Contains("POINTY_EARS")) }
    };

    public static string ClassifyCreature(Creature creature)
    {
        foreach (var raceCheck in _raceChecks)
        {
            if (raceCheck.Value(creature))
            {
                return raceCheck.Key;
            }
        }

        return "Unknown";
    }
}
