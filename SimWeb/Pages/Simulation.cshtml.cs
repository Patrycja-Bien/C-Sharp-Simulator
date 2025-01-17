using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using System.Linq;
using System.Collections.Generic;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    private static Simulator.Simulation? _simulation;
    private static SimulationHistory? _history;
    private static int _currentTurn = 0;

    public Dictionary<Point, List<char>>? Symbols { get; private set; }
    public int SizeX { get; private set; }
    public int SizeY { get; private set; }
    public int CurrentTurn => _currentTurn;

    public List<List<CreatureAtPoint>> MapGrid { get; set; } = new();

    public void OnGet()
    {
        if (_simulation == null)
        {
            BigBounceMap map = new(8, 6);
            List<IMappable> creatures = new List<IMappable>
            {
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Simulator.Animals { Description = "Rabbits", Size = 10 },
                new Simulator.Birds { Description = "Eagles", Size = 5 },
                new Simulator.Birds { Description = "Ostriches", Size = 5, CanFly = false }
            };
            List<Point> points = new List<Point>
            {
                new(5, 3),
                new(5, 0),
                new(0, 4),
                new(5, 4),
                new(0, 0)
            };
            string moves = "uruldrdlldldrruduldd";

            _simulation = new Simulator.Simulation(map, creatures, points, moves);
            _history = new SimulationHistory(_simulation);
            SizeX = map.SizeX;
            SizeY = map.SizeY;
        }

        UpdateSymbols();
        GenerateMapGrid();
    }

    public IActionResult OnPostNext()
    {
        if (_history != null)
        {
            _currentTurn = (_currentTurn + 1) % _history.TurnLogs.Count;
            UpdateSymbols();
            GenerateMapGrid();
        }

        return Page();
    }

    public IActionResult OnPostPrevious()
    {
        if (_history != null)
        {
            _currentTurn = (_currentTurn - 1 + _history.TurnLogs.Count) % _history.TurnLogs.Count;
            UpdateSymbols();
            GenerateMapGrid();
        }

        return Page();
    }

    private void UpdateSymbols()
    {
        Symbols = _history!.TurnLogs[_currentTurn].Symbols;
        SizeX = _history.SizeX;
        SizeY = _history.SizeY;
    }
    private void GenerateMapGrid()
    {
        MapGrid.Clear();

        for (int row = 5; row >= 0; row--)
        {
            var rowGrid = new List<CreatureAtPoint>();

            for (int col = 0; col < 8; col++)
            {
                var point = new Point(col, row);
                var creaturesAtPoint = Symbols?.FirstOrDefault(s => s.Key.Equals(point)).Value;

                rowGrid.Add(new CreatureAtPoint
                {
                    Point = point,
                    Creatures = creaturesAtPoint
                });
            }

            MapGrid.Add(rowGrid);
        }
    }
    public string GetImageSource(List<char> creatures)
    { 
        if (creatures.Contains('E'))
            return "<img src='/images/elf.jpg' alt='Elf' />";
        if (creatures.Contains('O'))
            return "<img src='/images/orc.jpg' alt='Orc' />";
        if (creatures.Contains('A'))
            return "<img src='/images/rabbits.jpg' alt='Rabbits' />";
        if (creatures.Contains('B'))
            return "<img src='/images/eagles.jpg' alt='Eagles' />";
        if (creatures.Contains('b'))
            return "<img src='/images/ostriches.jpg' alt='Ostriches' />";
        if (creatures.Contains('X'))
            return "<img src='/images/x.png' alt='X' />";

        return "";
    }

    public class CreatureAtPoint
    {
        public Point Point { get; set; }
        public List<char>? Creatures { get; set; }
    }
}