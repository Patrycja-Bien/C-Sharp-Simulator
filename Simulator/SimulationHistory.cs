using Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            _simulation.Turn();

            var symbols = new Dictionary<Point, List<char>>();
            foreach (var mappable in _simulation.IMappables)
            {
                if (!symbols.ContainsKey(mappable.Position))
                {
                    symbols[mappable.Position] = new List<char>();
                }
                symbols[mappable.Position].Add(mappable.Symbol);
            }

            var log = new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = symbols
            };

            TurnLogs.Add(log);
        }
    }
}