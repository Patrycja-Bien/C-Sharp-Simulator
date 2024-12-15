namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    private Rectangle boundaries;

    private Dictionary<Point, List<IMappable>> mappablesFields = new Dictionary<Point, List<IMappable>>();
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return boundaries.Contains(p);
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

    public virtual void Move(IMappable mappable, Point oldPoint, Point newPoint)
    {
        Remove(mappable, oldPoint);
        Add(mappable, newPoint);
    }

    public void Add(IMappable mappable, Point point)
    {
        if (!Exist(point))
            throw new ArgumentException($"Punkt {point} jest poza granicami mapy.");
        if (!mappablesFields.ContainsKey(point))
        {
            mappablesFields[point] = new List<IMappable>();
        }
        mappablesFields[point].Add(mappable);
    }

    public void Remove(IMappable mappable, Point point)
    {
        if (mappablesFields.ContainsKey(point))
        {
            mappablesFields[point].Remove(mappable);
            if (mappablesFields[point].Count == 0)
            {
                mappablesFields.Remove(point);
            }
        }
    }

    public List<IMappable> At(Point point)
    {
        if (mappablesFields.ContainsKey(point))
        {
            return mappablesFields[point];
        }
        return new List<IMappable>();
    }

    public List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy musi wynosić co najmniej 5.");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy musi wynosić co najmniej 5.");

        SizeX = sizeX;
        SizeY = sizeY;
        boundaries = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
}