using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator;

public class SimulationHistory
{
    private List<SimulationSnapshot> snapshots;
    private Simulation simulation;

    public SimulationHistory(Simulation simulation)
    {
        this.simulation = simulation;
        snapshots = new List<SimulationSnapshot>();
    }

    public void RecordTurn()
    {
        var snapshot = new SimulationSnapshot
        {
            Move = simulation.CurrentMoveName,
            MovedMappable = simulation.CurrentMappable
        };

        foreach (var mappable in simulation.IMappables)
        {
            snapshot.MappableStates.Add(new MappableState
            {
                Type = mappable.GetType().Name,
                Position = mappable.Position,
                Info = mappable.Info
            });
        }

        snapshots.Add(snapshot);
    }

    public void ReplayTurn(int turnNumber)
    {
        if (turnNumber <= 0 || turnNumber > snapshots.Count)
        {
            Console.WriteLine($"Invalid turn number {turnNumber}. Valid range: 1 to {snapshots.Count}.");
            return;
        }

        var snapshot = snapshots[turnNumber - 1];
        Console.WriteLine($"Replaying Turn {turnNumber}:");
        Console.WriteLine($"Move: {snapshot.MovedMappable.Info} - {snapshot.Move}");

        foreach (var state in snapshot.MappableStates)
        {
            Console.WriteLine($"{state.Info} (Class: {state.Type}) at {state.Position}");
        }
    }

}

public class SimulationSnapshot
{
    public List<MappableState> MappableStates { get; set; } = new List<MappableState>();
    public string Move { get; set; } = string.Empty;
    public required IMappable MovedMappable { get; set; }
}


public class MappableState
{
    public required string Type { get; set; }
    public Point Position { get; set; }
    public required string Info { get; set; }
}
