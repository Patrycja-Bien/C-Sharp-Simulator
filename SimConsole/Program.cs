using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            BigBounceMap map = new(6, 8);
            List<IMappable> mappables = new()
            {
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals { Description = "Rabbits", Size = 10 },
                new Birds { Description = "Eagles", Size = 5 },
                new Birds { Description = "Ostriches", Size = 5, CanFly = false }
            };
            List<Point> points = new()
            {
                new(5, 7),
                new(5, 0),
                new(0, 7),
                new(5, 4),
                new(0, 0)
            };

            string moves = "uruldrdlldldrruduldd";
            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            SimulationHistory history = new(simulation);
            LogVisualizer logVisualizer = new(history);

            //while (!simulation.Finished)
            //{
            //    mapVisualizer.Draw();
            //    Console.WriteLine("\nPress any key to make a move...");
            //    Console.ReadKey(true);
            //    simulation.Turn();
            //    Console.Clear();
            //}
            //mapVisualizer.Draw();
            //Console.ReadKey(true);

            Console.WriteLine("Turn 1: ");
            logVisualizer.Draw(0);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Turn 3: ");
            logVisualizer.Draw(2);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Turn 5: ");
            logVisualizer.Draw(4);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Turn 20: ");
            logVisualizer.Draw(19);
            Console.WriteLine("Press any key to continue...");
        }

    }
}
