using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;
public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int sizeX = _map.SizeX;
        int sizeY = _map.SizeY;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1)
            {
                Console.Write(Box.TopMid);
            }
        }
        Console.WriteLine(Box.TopRight);

        for (int y = sizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < sizeX; x++)
            {
                var creatures_on_point = _map.At(new Point(x, y));
                if (creatures_on_point == null || creatures_on_point.Count() == 0)
                {
                    Console.Write(' ');
                }
                else if (creatures_on_point.Count() > 1)
                {
                    Console.Write('X');
                }
                else if (creatures_on_point.Count() == 1 && creatures_on_point[0] is Elf)
                {
                    Console.Write('E');
                }
                else
                {
                    Console.Write('O');
                }

                if (x < sizeX - 1)
                {
                    Console.Write(Box.Vertical);
                }
            }
            Console.WriteLine(Box.Vertical);

            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < sizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < sizeX - 1)
                    {
                        Console.Write(Box.Cross);
                    }
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1)
            {
                Console.Write(Box.BottomMid);
            }
        }
        Console.WriteLine(Box.BottomRight);
    }

}

