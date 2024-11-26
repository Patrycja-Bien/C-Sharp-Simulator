using Simulator.Maps;
namespace Simulator;
public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; private set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            int turnIndex = Moves.Length % Creatures.Count;
            return Creatures[turnIndex];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Moves.Length != 0)
            {
                return Moves[0].ToString().ToLower();
            }
            return string.Empty;
            
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("List of creatures is empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures don't match the number of positions.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));
        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentOutOfRangeException($"Position is outside of the map.");
            }
            creature.InitMapAndPosition(map, position);

            map.Add(position, creature);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is finished.");
        }

        if (Moves.Length == 0)
        {
            Finished = true;
            return;
        }

        char currentMove = Moves[0];
        Moves = Moves.Substring(1);

        var directions = DirectionParser.Parse(currentMove.ToString());
        if (directions.Count == 0)
        {
            return;
        }

        Direction direction = directions[0];

        CurrentCreature.Go(direction);

        if (Moves.Length == 0)
        {
            Finished = true;
        }
    }
}