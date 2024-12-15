using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; set; }
    Point Position { get; set; }
    abstract char Symbol { get; }
    public string ToString();
    string Info { get; }
    virtual void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("The creature is not assigned to any map.");

        Point nextPosition = Map.Next(Position, direction);

        if (nextPosition.Equals(Position))
        {
            throw new InvalidOperationException("The creature is already at given point.");
        }
        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
    }
    virtual void InitMapAndPosition(Map map, Point p)
    {
        if (Map != null)
            throw new InvalidOperationException("Mappable is already assigned to a map.");

        Map = map ?? throw new ArgumentNullException(nameof(map));

        if (!map.Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Position is out of bounds.");

        Position = p;
        Map.Add(this, p);
    }
}
