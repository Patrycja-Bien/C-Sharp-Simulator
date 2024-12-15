using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public virtual char Symbol => 'A';
    public Map? Map { get; set; }
    public Point Position { get; set; }
    public required string Description
    {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;
    public override string ToString()
    {
        string DescName = GetType().Name.ToUpper();
        return $"{DescName}: {Info}";
    }
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
    public virtual void Go(Direction direction)
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
}
