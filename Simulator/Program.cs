using Simulator.Maps;
using System.Diagnostics;
using System.Numerics;

namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        static void Lab5a()
        {
            Console.WriteLine("POINT CREATION AND METHODS TEST\n");
            Point p = new(10, 25);
            Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
            Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

            Console.WriteLine("\nRECTANGLE CREATION TEST\n");
            var r1 = new Rectangle(1, 2, 3, 4);
            Console.WriteLine(r1); // (1, 2):(3, 4)
            var r2 = new Rectangle(new Point(5, 6), new Point(7, 8));
            Console.WriteLine(r2); // (5, 6):(7, 8)

            Console.WriteLine("\nCOORDINATE ORDER TEST\n");
            var r3 = new Rectangle(3, 4, 1, 2);
            Console.WriteLine(r3); // (1, 2):(3, 4)
            var r4 = new Rectangle(new Point(7,8), new Point(5,6));
            Console.WriteLine(r4); // (5, 6):(7, 8)

            Console.WriteLine("\nHANDLE EXCEPTION TEST\n");
            try
            {
                var r5 = new Rectangle(0, 1, 0, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia prostokąta r5: {ex.Message}");
            }
            try
            {
                var r6 = new Rectangle(new Point(1, 5), new Point(2, 5));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia prostokąta r6: {ex.Message}");
            }

            var r7 = new Rectangle(0, 0, 6, 6);

            Console.WriteLine("\nCONTAINS METHOD TEST\n");
            Console.WriteLine(r7.Contains(new Point(-1,-1))); //False
            Console.WriteLine(r7.Contains(new Point(6, 6))); //True
            Console.WriteLine(r7.Contains(new Point(2,2))); //True
            }
        Lab5a();
        static void Lab5b()
        {
            Console.WriteLine("\nSMALLSQUAREMAP SIZE TEST\n");
            try
            {
                var m1 = new SmallSquareMap(1);
                Console.WriteLine("Mapa m1 utworzona poprawnie");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia mapy m1: {ex.Message}");
            }
            try
            {
                var m2 = new SmallSquareMap(10);
                Console.WriteLine("Mapa m2 utworzona poprawnie");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia mapy m2: {ex.Message}");
            }

            Console.WriteLine("\nSMALLSQUAREMAP EXIST TEST\n");
            var m3 = new SmallSquareMap(10);
            Console.WriteLine(m3.Exist(new Point(2, 2))); //True
            Console.WriteLine(m3.Exist(new Point(10, 10))); //True
            Console.WriteLine(m3.Exist(new Point(-2, -2))); //False

            Console.WriteLine("\nSMALLSQUAREMAP NEXT TEST\n");
            Console.WriteLine(m3.Next(new Point(9, 10), Direction.Up)); //(9, 10)
            Console.WriteLine(m3.Next(new Point(9, 10), Direction.Down)); //(9, 9)
            Console.WriteLine(m3.Next(new Point(-1, -1), Direction.Down)); //(-1, -1)

            Console.WriteLine("\nSMALLSQUAREMAP NEXTDIAGONAL TEST\n");
            Console.WriteLine(m3.NextDiagonal(new Point(9, 10), Direction.Up)); //(9, 10)
            Console.WriteLine(m3.NextDiagonal(new Point(9, 10), Direction.Down)); //(8, 9)
            Console.WriteLine(m3.NextDiagonal(new Point(-1, -1), Direction.Down)); //(-1, -1)
        }
        Lab5b();
    }
}
