using System.Diagnostics;

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
            Console.WriteLine(r7.Contains(new Point(-1,-1))); 
            Console.WriteLine(r7.Contains(new Point(6, 6)));
            Console.WriteLine(r7.Contains(new Point(2,2)));
            }
        Lab5a();
    }
}
