using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Simulator;
using Simulator.Maps;
using Point = Simulator.Point;

namespace SimConsole
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SmallSquareMap map = new(5);
            List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor") };
            List<Point> points = new() { new(2, 2), new(3, 1) };
            string moves = "dlrludl";

            //SmallTorusMap map = new(6, 8);
            //List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Strusie") };
            //List<Point> points = new() { new(2, 2), new(3, 1) };
            //string moves = "dlrludl";
            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            //dokończyć

            var move = 1;
            mapVisualizer.Draw();
            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to proceed to the next turn...");
                Console.ReadKey(true);

                Console.WriteLine($"Turn {move}");
                Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");

                Console.WriteLine();
                simulation.Turn();
                mapVisualizer.Draw();
                move++;

            }
        }
    }
}