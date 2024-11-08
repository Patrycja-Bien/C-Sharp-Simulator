using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public readonly int Size;
    public SmallSquareMap(int size)
    {
        if ((size < 5) || (size > 20))
        {
            throw new ArgumentOutOfRangeException("Wprowadzony rozmiar nie należy do akceptowanego przedziału [5,20]");
        }
        else
        {
            Size = size;
        }
    }
    public override bool Exist(Point p)
    {
        var R = new Rectangle(0,0, Size, Size);
        return R.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var newPoint = p.Next(d);
        if (Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        if (Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }
}
