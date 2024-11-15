using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;

    private readonly Rectangle r;

    public SmallTorusMap(int size)
    {
        if ((size < 5) || (size > 20))
        {
            throw new ArgumentOutOfRangeException("Wprowadzony rozmiar nie należy do akceptowanego przedziału [5,20]");
        }
        else
        {
            Size = size;
            r = new Rectangle(0, 0, Size, Size);
        }
    }
    public override bool Exist(Point p)
    {
        return r.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var newPoint = p.Next(d);
        int newX = (newPoint.X + Size) % Size;
        int newY = (newPoint.Y + Size) % Size;

        return new Point(newX, newY);
    }
    

    public override Point NextDiagonal(Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        int newX = (newPoint.X + Size) % Size;
        int newY = (newPoint.Y + Size) % Size;

        return new Point(newX, newY);
    }
}
