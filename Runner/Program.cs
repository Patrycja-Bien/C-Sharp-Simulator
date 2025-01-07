using Simulator.Maps;
using System.Diagnostics;
using System.Numerics;

namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        var creatures = new List<Creature>
        {
            new Elf("A", level: 3, agility: 8),
            new Orc("B", level: 7, rage: 6),
            new Elf("C", level: 5, agility: 10),
            new Orc("D", level: 1, rage: 8),
            new Elf("E", level: 6, agility: 9),
            new Orc("F", level: 10, rage: 5),
            new Elf("G", level: 2, agility: 6),
            new Orc("H", level: 8, rage: 7),
        };

        Console.WriteLine("Creatures before sorting:");
        foreach (var creature in creatures)
        {
            Console.WriteLine($"{creature} Power: {creature.Power}");
        }

        creatures.Sort((a, b) => a.Power.CompareTo(b.Power));

        Console.WriteLine("\nCreatures after sorting by Power:");
        foreach (var creature in creatures)
        {
            Console.WriteLine($"{creature} Power: {creature.Power}");
        }


    }
}
