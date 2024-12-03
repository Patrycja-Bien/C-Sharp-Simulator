using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<IMappable>?[,] fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high");

        fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(Point p, IMappable mappable)
    {
        if (Exist(p))
        {
            if (fields[p.X, p.Y] == null)
            {
                fields[p.X, p.Y] = new List<IMappable>();
            }
            if (!fields[p.X, p.Y]!.Contains(mappable))
            {
                fields[p.X, p.Y]!.Add(mappable);
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }
    }


    public override void Remove(Point p, IMappable mappable)
    {
        if (Exist(p))
        {
            if (fields[p.X, p.Y] != null)
            {
                fields[p.X, p.Y]?.Remove(mappable);
                if (fields[p.X, p.Y]?.Count == 0)
                {
                    fields[p.X, p.Y] = null;
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }
    }

    public override List<IMappable> At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Point is out of bounds.");

        return fields[p.X, p.Y] ?? new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
    public override void Move(Point oldP, Point newP, IMappable mappable)
    {
        if (!Exist(oldP) || !Exist(newP))
            throw new ArgumentOutOfRangeException("Points are out of map bounds.");

        if (fields[oldP.X, oldP.Y]?.Contains(mappable) != true)
            throw new InvalidOperationException("Mappable does not exist at the old position.");

        Remove(oldP, mappable);
        Add(newP, mappable);
    }
}