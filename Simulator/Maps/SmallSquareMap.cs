using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
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
