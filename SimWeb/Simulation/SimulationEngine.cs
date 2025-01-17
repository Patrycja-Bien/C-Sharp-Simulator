namespace SimWeb.Simulation;

public class SimulationEngine
{
    public int Step { get; private set; }
    public List<string> History { get; private set; }

    public SimulationEngine()
    {
        Step = 0;
        History = new List<string>();
    }

    public void RunStep()
    {
        Step++;
        History.Add($"Step {Step} executed at {DateTime.Now}");
    }
}
