using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Simulator;
using Simulator.Maps;
using Point = Simulator.Point;

namespace SimConsole;

public class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(6, 8);
        List<IMappable> mappables = new() 
        { 
            new Orc("Gorbag"), 
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 5 },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };
        List<Point> points = new() { new(2, 2), new(3, 1), new(1,3), new(2,1), new(4,3) };
        string moves = "dlrludlruuddlrd";
        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        var move = 1;
        mapVisualizer.Draw();
        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to proceed to the next turn...");
            Console.ReadKey(true);

            Console.WriteLine($"Turn {move}");
            Console.Write($"{simulation.CurrentMappable.Info} - current position: {simulation.CurrentMappable.Position}, move: {simulation.CurrentMoveName}\n");

            Console.WriteLine();
            simulation.Turn();
            mapVisualizer.Draw();
            move++;

        }
    }
}