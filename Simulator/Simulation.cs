﻿using Simulator.Maps;
using Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> IMappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; private set; }
    public bool Finished { get; private set; } = false;

    private readonly List<Direction> directions;

    private int turn = 0;

    public IMappable CurrentMappable => IMappables[turn % IMappables.Count];
    public string CurrentMoveName => directions[turn % directions.Count].ToString().ToLower();
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
            throw new ArgumentException("The mappables list cannot be empty.");

        if (mappables.Count != positions.Count)
            throw new ArgumentException("The number of mappables must match the number of starting positions.");

        if (positions.Distinct().Count() != positions.Count)
            throw new ArgumentException("The positions list contains duplicate positions.");

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        directions = DirectionParser.Parse(moves);

        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");

            mappable.InitMapAndPosition(map, position);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("The simulation is already finished.");

        if (directions.Count == 0)
        {
            Finished = true;
            return;
        }

        var direction = directions[turn % directions.Count];

        try
        {
            CurrentMappable.Go(direction);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error moving mappable: {ex.Message}");
        }

        turn++;

        if (turn >= directions.Count)
        {
            Finished = true;
        }
    }
}
