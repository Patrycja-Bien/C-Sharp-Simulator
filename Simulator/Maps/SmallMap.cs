using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>[,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high");

        _fields = new List<Creature>[sizeX, sizeY];

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                _fields[x, y] = new List<Creature>();
            }
        }
    }

    public void Add(Point p, Creature creature)
    {
        if (Exist(p))
        {
            _fields[p.X, p.Y].Add(creature);
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
            _fields[p.X, p.Y].Remove(creature);
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
            return _fields[p.X, p.Y];
        }
        else
        {
            throw new ArgumentOutOfRangeException("Given point doesn't exist on the map");
        }
    }
    public List<Creature> At(int x, int y)
    {
        return At(new Point(x,y));
    }

    public void Move(Point oldP, Point newP, Creature creature)
    {
        Remove(oldP, creature);
        Add(newP, creature);
    }
}
