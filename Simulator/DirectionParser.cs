using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class DirectionParser
{
    public static List<Direction> Parse(string dirs)
    {
        List<Direction> result = new();
        for (int i = 0; i < dirs.Length; i++)
        {
            if (dirs[i].ToString().Equals("U", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(Direction.Up);
            }
            else if (dirs[i].ToString().Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(Direction.Right);
            }
            else if (dirs[i].ToString().Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(Direction.Down);
            }
            else if (dirs[i].ToString().Equals("L", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(Direction.Left);
            }
            else
            {
                continue;
            }


        }
        return result;
    }
}
