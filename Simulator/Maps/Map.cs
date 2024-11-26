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
    //Add(Creature, Point)
    //Remove(Creature, Point)
    //Move()
    //At(Point) albo x, y
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
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Point p, Creature creature)
    {
        if (Exist(p))
        {
            _Fields[p.X, p.Y] = new List<Creature>();
            _Fields[p.X, p.Y]?.Add(creature);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }

    }

    public void Remove(Point p, Creature creature)
    {
        if (Exist(p))
        {
            _Fields[p.X, p.Y]?.Remove(creature);
            if (_Fields[p.X, p.Y]?.Count == 0)
                _Fields[p.X, p.Y] = null;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }

    }
    public List<Creature> At(Point p)
    {
        if (Exist(p))
        {
            return _Fields[p.X, p.Y] ?? new List<Creature>();
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }
    }
    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public void Move(Point oldP, Point newP, Creature creature)
    {
        Remove(oldP, creature);
        Add(newP, creature);
    }
}
