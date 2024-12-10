using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigMap : Map
{
    private Dictionary<Point, List<IMappable>> fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high");

        fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(Point p, IMappable mappable)
    {
        if (Exist(p))
        {
            if (!fields.ContainsKey(p))
            {
                fields[p] = new List<IMappable>();
            }

            fields[p].Add(mappable);
        }
        else throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
    }

    public override void Remove(Point p, IMappable mappable)
    {
        if (Exist(p))
        {
            fields[p].Remove(mappable);
        }
        else throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
    }

    public override List<IMappable> At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Point is out of bounds.");
        if (fields.ContainsKey(p))
        {
            return fields[p];
        }
        else return new List<IMappable>();
        
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override void Move(Point oldP, Point newP, IMappable mappable)
    {
        if (!Exist(oldP) || !Exist(newP))
            throw new ArgumentOutOfRangeException("Points are out of map bounds.");

        if (fields[oldP].Contains(mappable) != true)
            throw new InvalidOperationException("Mappable does not exist at the old position.");

        Remove(oldP, mappable);
        Add(newP, mappable);
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
