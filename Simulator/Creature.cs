using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point p)
    {
        if (Map != null)
            throw new InvalidOperationException($"{Name} is already assigned to a map.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        if (!map.Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Position is out of bounds.");

        Position = p;
        Map.Add(p, this);
    }
    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value,3,25,'#');
        }
    }

    private int level = 1;
    public int Level 
    { 
        get {  return level; }
        set
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {

    }
    public abstract string Greeting();

    public string Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("The creature is not assigned to any map.");

        Point nextPosition = Map.Next(Position, direction);

        if (nextPosition.X == Position.X && nextPosition.Y == Position.Y)
        {
            return $"{Name} is already at the given position.";
        }
        Map.Move(Position, nextPosition, this);
        Position = nextPosition;

        return $"{direction.ToString().ToLower()}";
    }
    public void Upgrade()
    {
        if ( Level < 10 )
        {
            level++;
        }
    }

    public override string ToString()
    {
        string creatureName = GetType().Name.ToUpper();
        return $"{creatureName}: {Info}";
    }
    public abstract string Info { get; }
}
