using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simulator;

public class Birds: Animals
{
    public bool CanFly { get; set; } = true;

    [JsonIgnore]
    public override char Symbol => CanFly ? 'B' : 'b';

    [JsonIgnore]
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
            Point firstStep = Map.Next(Position, direction);
            Point secondStep = Map.Next(firstStep, direction);

            if (!Map.Exist(firstStep))
            {
                nextPosition = Position;
                nextPosition = Map.Next(nextPosition, Opposite(direction));
                nextPosition = Map.Next(nextPosition, Opposite(direction));
            }
            else if (!Map.Exist(secondStep))
            {
                nextPosition = Map.Next(firstStep, Opposite(direction));
            }
            else
            {
                nextPosition = secondStep;
            }
        }
        else
        {
            nextPosition = Map.NextDiagonal(Position, direction);
        }

        if (nextPosition.Equals(Position))
        {
            throw new InvalidOperationException("The creature is already at the given point.");
        }

        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
    }

    private Direction Opposite(Direction direction)
    {
        return direction switch
        {
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            _ => throw new ArgumentException("Invalid direction")
        };
    }

}

