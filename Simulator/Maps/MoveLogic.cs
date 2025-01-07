using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public static class MoveLogic
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        var newPoint = p.Next(d);
        if (m.Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }

    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        if (m.Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }

    public static Point TorusNext(Map m, Point p, Direction d)
    {
        var newPoint = p.Next(d);
        int newX = (newPoint.X + m.SizeX) % m.SizeX;
        int newY = (newPoint.Y + m.SizeY) % m.SizeY;

        return new Point(newX, newY);
    }
    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        int newX = (newPoint.X + m.SizeX) % m.SizeX;
        int newY = (newPoint.Y + m.SizeY) % m.SizeY;

        return new Point(newX, newY);
    }

    public static Point BounceNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        int newX = nextPoint.X;
        int newY = nextPoint.Y;

        if (newX < 0)
            newX = p.X + 1;
        else if (newX >= m.SizeX)
            newX = p.X - 1;

        if (newY < 0)
            newY = p.Y + 1;
        else if (newY >= m.SizeY)
            newY = p.Y - 1;

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }

    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);

        int newX = nextPoint.X;
        int newY = nextPoint.Y;

        if (newX < 0 || newX >= m.SizeX)
            newX = p.X - (nextPoint.X - p.X);

        if (newY < 0 || newY >= m.SizeY)
            newY = p.Y - (nextPoint.Y - p.Y);

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }
}
