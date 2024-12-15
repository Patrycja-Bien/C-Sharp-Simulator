using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private Dictionary<Point, List<IMappable>> fields;

    private readonly Rectangle r;
    protected Map(int sizeX, int sizeY)
    {
        if ((sizeX < 5) || (sizeY < 5))
        {
            throw new ArgumentOutOfRangeException("Map too small");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        r = new Rectangle(0,0, SizeX - 1, SizeY - 1);
        fields = new Dictionary<Point, List<IMappable>>();
    }
    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return r.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point Next(Point p, Direction d)
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

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point NextDiagonal(Point p, Direction d)
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
    public virtual void Add(Point p, IMappable mappable)
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

    public virtual void Remove(Point p, IMappable mappable)
    {
        if (Exist(p))
        {
            fields[p].Remove(mappable);
        }
        else throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
    }

    public virtual List<IMappable> At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Point is out of bounds.");
        if (fields.ContainsKey(p))
        {
            return fields[p];
        }
        else return new List<IMappable>();

    }

    public virtual List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public virtual void Move(Point oldP, Point newP, IMappable mappable)
    {
        if (!Exist(oldP) || !Exist(newP))
            throw new ArgumentOutOfRangeException("Points are out of map bounds.");

        if (fields[oldP].Contains(mappable) != true)
            throw new InvalidOperationException("Mappable does not exist at the old position.");

        Remove(oldP, mappable);
        Add(newP, mappable);
    }
}
