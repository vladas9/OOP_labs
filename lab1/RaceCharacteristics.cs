public static class RaceCharacteristics
{
    private static readonly Dictionary<(string universe, string raceName), Func<Creature, bool>> _raceChecks = new()
    {
        // Star Wars Universe: Wookie
        { ("Star Wars", "Wookie"), creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                                               (creature.planet == null || creature.planet == "Kashyyyk") &&
                                               (creature.age == null || (creature.age >= 0 && creature.age <= 400)) &&
                                               (creature.traits == null ||
                                                creature.traits.Contains("HAIRY") ||
                                                creature.traits.Contains("TALL")) },
        // Star Wars Universe: Ewok
        { ("Star Wars", "Ewok"), creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                                             (creature.planet == null || creature.planet == "Endor") &&
                                             (creature.age == null || (creature.age >= 0 && creature.age <= 60)) &&
                                             (creature.traits == null ||
                                              creature.traits.Contains("SHORT") ||
                                              creature.traits.Contains("HAIRY")) },
        // Marvel Universe: Asgardian
        { ("Marvel", "Asgardian"), creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                               (creature.planet == null || creature.planet == "Asgard") &&
                                               (creature.age == null || (creature.age >= 0 && creature.age <= 5000)) &&
                                               (creature.traits == null ||
                                                creature.traits.Contains("BLONDE") ||
                                                creature.traits.Contains("TALL")) },
        // Hitchhiker's Universe: Betelgeusian
        { ("Hitchhiker's", "Betelgeusian"), creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                                       (creature.planet == null || creature.planet == "Betelgeuse") &&
                                                       (creature.age == null || (creature.age >= 0 && creature.age <= 100)) &&
                                                       (creature.traits == null ||
                                                        creature.traits.Contains("EXTRA_ARMS") ||
                                                        creature.traits.Contains("EXTRA_HEAD")) },
        // Hitchhiker's Universe: Vogon
        { ("Hitchhiker's", "Vogon"), creature => (creature.isHumanoid == null || creature.isHumanoid == false) &&
                                                 (creature.planet == null || creature.planet == "Vogsphere") &&
                                                 (creature.age == null || (creature.age >= 0 && creature.age <= 200)) &&
                                                 (creature.traits == null ||
                                                  creature.traits.Contains("GREEN") ||
                                                  creature.traits.Contains("BULKY")) },
        // Lord of the Rings Universe: Dwarf
        { ("Lord of the Rings", "Dwarf"), creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                                     (creature.planet == null || creature.planet == "Earth") &&
                                                     (creature.age == null || (creature.age >= 0 && creature.age <= 200)) &&
                                                     (creature.traits == null ||
                                                      creature.traits.Contains("SHORT") ||
                                                      creature.traits.Contains("BULKY")) },
        // Lord of the Rings Universe: Elf
        { ("Lord of the Rings", "Elf"), creature => (creature.isHumanoid == null || creature.isHumanoid == true) &&
                                                   (creature.planet == null || creature.planet == "Earth") &&
                                                   (creature.traits == null ||
                                                    creature.traits.Contains("BLONDE") ||
                                                    creature.traits.Contains("POINTY_EARS")) }
    };

    public static (string universe, string raceName) ClassifyCreature(Creature creature)
    {
        foreach (var raceCheck in _raceChecks)
        {
            if (raceCheck.Value(creature))
            {
                return raceCheck.Key;
            }
        }

        return ("Unknown", "Unknown");
    }
}
