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
            SimulationHistory simulationHistory = new(simulation);

            int turn = 1;

            simulationHistory.RecordTurn();
            mapVisualizer.Draw();

            while (!simulation.Finished)
            {
                Console.Clear();
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine($"{simulation.CurrentMappable.Info} - current position: {simulation.CurrentMappable.Position}, move: {simulation.CurrentMoveName}");
                mapVisualizer.Draw();

                Console.WriteLine("\nPress any key to continue to the next turn...");
                Console.ReadKey();

                simulation.Turn();
                simulationHistory.RecordTurn();

                turn++;
            }

            Console.Clear();
            Console.WriteLine("Simulation Finished.replaying turns.");
            simulationHistory.ReplayTurn(5);
            simulationHistory.ReplayTurn(10);
            simulationHistory.ReplayTurn(15);
            simulationHistory.ReplayTurn(20);
            Console.WriteLine("\nYou can replay specific turns.");
            while (true)
            {
                Console.WriteLine("Enter a turn number to replay (or type anything else to quit): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int turnNumber))
                {
                    Console.Clear();
                    simulationHistory.ReplayTurn(turnNumber);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
