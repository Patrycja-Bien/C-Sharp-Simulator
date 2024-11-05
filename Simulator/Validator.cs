using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {

        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        else
        {
            return value;
        }
 
    
    }

    public static string Shortener(string value, int min, int max, char placeholder)
        {
            var name = value.Trim();
            if (name.Length > max)
            {
                name = name.Substring(0, max).Trim();
            }
            if (name.Length < min)
            {
                int missing = min - name.Length;
                string ph = String.Concat(Enumerable.Repeat(placeholder, missing));
                name = $"{name}{ph}";
            }
            if (char.IsLower(name[0]))
            {
                name = (char.ToUpper(name[0]) + name.Substring(1));
            }
        return name;
        }
    }
