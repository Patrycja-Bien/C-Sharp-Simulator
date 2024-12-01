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
    public abstract void Add(Point p, IMappable creature);
    public abstract void Remove(Point p, IMappable mappable);
    public abstract List<IMappable> At(Point p);
    public abstract List<IMappable> At(int x, int y);
    public abstract void Move(Point oldP, Point newP, IMappable mappable);
}
