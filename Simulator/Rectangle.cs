using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Rectangle
{
    public readonly int X1;
    public readonly int Y1;
    public readonly int X2;
    public readonly int Y2;

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if ((x1 == x2) || (y1 == y2))
        {
            throw new ArgumentException("Punkty nie mogą być współliniowe");
        }
        X1 = (x1 < x2) ? x1 : x2;
        X2 = (x1 < x2) ? x2 : x1;
        
        Y1 = (y1 < y2) ? y1 : y2;
        Y2 = (y1 < y2) ? y2 : y1;
    }
    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
    }

    public bool Contains(Point point)
    {
        if ((point.X > X1) && (point.X < X2))
        {
            if ((point.Y > Y1) && (point.Y < Y2))
            {
                return true;
            }
        }
        return false;
    }
}
