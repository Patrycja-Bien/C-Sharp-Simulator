using Simulator;

namespace SimConsole;

public class LogVisualizer
{
    private readonly SimulationHistory _history;

    public LogVisualizer(SimulationHistory history)
    {
        _history = history;
    }

    public void Draw(int turn)
    {
        if (turn < 0 || turn >= _history.TurnLogs.Count)
        {
            Console.WriteLine("Invalid turn number.");
            return;
        }

        var log = _history.TurnLogs[turn];
        DrawMap(log.Symbols, _history.SizeX, _history.SizeY);
    }

    private void DrawMap(Dictionary<Point, List<char>> symbols, int sizeX, int sizeY)
    {
        Console.Write(Box.TopLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);
        for (int y = sizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < sizeX; x++)
            {
                var point = new Point(x, y);
                if (symbols.TryGetValue(point, out List<char> symbolList))
                {
                    if (symbolList.Count > 1)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write(symbolList[0]);
                    }
                }
                else
                {
                    Console.Write(' ');
                }
                if (x < sizeX - 1)
                {
                    Console.Write(Box.Vertical);
                }
            }
            Console.WriteLine(Box.Vertical);
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < sizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < sizeX - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}