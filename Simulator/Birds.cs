using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds: Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }


    }
    public override void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("The creature is not assigned to any map.");

        Point nextPosition;

        if (CanFly)
        {
            nextPosition = Map.Next(Position, direction);
            nextPosition = Map.Next(nextPosition, direction);
        }
        else
        {
            nextPosition = Map.NextDiagonal(Position, direction);
        }

        if (nextPosition.Equals(Position))
        {
            throw new InvalidOperationException("The creature is already at given point.");
        }
        Map.Move(Position, nextPosition, this);
        Position = nextPosition;
    }
}

