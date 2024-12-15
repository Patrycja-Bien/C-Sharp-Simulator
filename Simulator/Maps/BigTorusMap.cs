using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }
    public override Point Next(Point p, Direction d)
    {
        var newPoint = p.Next(d);
        int newX = (newPoint.X + SizeX) % SizeX;
        int newY = (newPoint.Y + SizeY) % SizeY;

        return new Point(newX, newY);
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        int newX = (newPoint.X + SizeX) % SizeX;
        int newY = (newPoint.Y + SizeY) % SizeY;

        return new Point(newX, newY);
    }
}
