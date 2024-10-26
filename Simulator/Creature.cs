using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init
        {
            name = value.Trim();
            if (name.Length > 25)
            {
                name = name.Substring(0, 25).Trim();
            }
            if (name.Length < 3)
            {
                int missing = 3 - name.Length;
                string hash = String.Concat(Enumerable.Repeat("#", missing));
                name = $"{name}{hash}";
            }
            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
            }

        }
    }

    private int level = 1;
    public int Level 
    { 
        get {  return level; }
        set
        {
            if (level == 1)
            {
                if (value < 1)
                {
                    level = 1;
                }
                else if (value > 10)
                {
                    level = 10;
                }
                else
                {
                    level = value;
                }
            }
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {

    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public void Go(Direction direction)
    {
        string dir = direction.ToString();
        Console.WriteLine($"{Name} goes {char.ToLower(dir[0])+dir.Substring(1)}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }

    public void Upgrade()
    {
        if ( Level < 10 )
        {
            level++;
        }
    }
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
}
