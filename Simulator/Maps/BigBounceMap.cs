using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        int newX = nextPoint.X;
        int newY = nextPoint.Y;

        if (newX < 0)
            newX = p.X + 1;
        else if (newX >= SizeX)
            newX = p.X - 1;

        if (newY < 0)
            newY = p.Y + 1;
        else if (newY >= SizeY)
            newY = p.Y - 1;

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);

        int newX = nextPoint.X;
        int newY = nextPoint.Y;

        if (newX < 0 || newX >= SizeX)
            newX = p.X - (nextPoint.X - p.X);

        if (newY < 0 || newY >= SizeY)
            newY = p.Y - (nextPoint.Y - p.Y);

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }

}
