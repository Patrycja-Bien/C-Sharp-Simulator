using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    public string? Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level = 1)
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
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
}
