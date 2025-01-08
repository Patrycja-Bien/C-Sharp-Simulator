using Simulator.Maps;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        //var creatures = new List<Creature>
        //{
        //    new Elf("A", level: 3, agility: 8),
        //    new Orc("B", level: 7, rage: 6),
        //    new Elf("C", level: 5, agility: 10),
        //    new Orc("D", level: 1, rage: 8),
        //    new Elf("E", level: 6, agility: 9),
        //    new Orc("F", level: 10, rage: 5),
        //    new Elf("G", level: 2, agility: 6),
        //    new Orc("H", level: 8, rage: 7),
        //};

        //Console.WriteLine("Creatures before sorting:");
        //foreach (var creature in creatures)
        //{
        //    Console.WriteLine($"{creature} Power: {creature.Power}");
        //}

        //creatures.Sort((a, b) => a.Power.CompareTo(b.Power));

        //Console.WriteLine("\nCreatures after sorting by Power:");
        //foreach (var creature in creatures)
        //{
        //    Console.WriteLine($"{creature} Power: {creature.Power}");
        //}

        //var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        //Orc o1 = new("Gorbag", 3, 5);
        //string json = JsonSerializer.Serialize(o1, jsonOptions);
        //Console.WriteLine(json);

        //Orc? o2 = JsonSerializer.Deserialize<Orc>(json);
        //Console.WriteLine(o2);

        //Point p1 = new(2, 4);
        //string json = JsonSerializer.Serialize(p1);
        //Console.WriteLine(json); // {}

        //Point p2 = JsonSerializer.Deserialize<Point>(json);
        //Console.WriteLine(p2);

        //var jsonOptions = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    PropertyNameCaseInsensitive = true
        //};

        //Orc o1 = new("Gorbag", 3, 5);
        //Console.WriteLine(o1);

        //string filePath = "orc.json";
        //using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //{
        //    JsonSerializer.Serialize(fs, o1, jsonOptions);
        //}
        //using (FileStream fs = new FileStream(filePath, FileMode.Open))
        //{
        //    var o2 = JsonSerializer.Deserialize<Orc>(fs, jsonOptions);
        //    Console.WriteLine(o2);
        //}

        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        //Orc o1 = new("Gorbag", 3, 5);
        //Orc o2 = new("Morgash", 2, 7);

        //List<Orc> orcs = new() { o1, o2, o1 };
        //Console.WriteLine(orcs[0] == orcs[2]); // True

        //string json = JsonSerializer.Serialize(orcs, options);
        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //List<Orc> deserialized =
        //    JsonSerializer.Deserialize<List<Orc>>(json, options)!;

        //Console.Write("\nReference preserved:");
        //Console.WriteLine(deserialized[0] == deserialized[2]);

        //var options = new JsonSerializerOptions { WriteIndented = true };

        //List<Creature> creatures = [
        //    new Orc("Gorbag", 3, 5),
        //    new Elf("Legolas", 2, 7)
        //];
        //string json = JsonSerializer.Serialize(creatures, options);
        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //List<Creature> deserialized =
        //    JsonSerializer.Deserialize<List<Creature>>(json, options)!;

        //Console.WriteLine("\nPolimorfic OK:");
        //Console.WriteLine(deserialized[0] is Orc);
        //Console.WriteLine(deserialized[1] is Elf);

        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
            new Elf("Elandor", 2, 7),
            new Animals { Description = "Rasbbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 15 },
            new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
    }
}
