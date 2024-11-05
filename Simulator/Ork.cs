using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;

    public override int Power
    {
        get { return (7 * Level + 3 * Rage); }
    }
    
    private int rage;
    public int Rage
    {
        get { return rage; }
        init
        {
            if (value < 1)
            {
                rage = 1;
            }
            else if (value > 10)
            {
                rage = 10;
            }
            else
            {
                rage = value;
            }
        }
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() { }

    public void Hunt()
    {
        huntCount++;
        if (huntCount % 2 == 0)
        {
            if (rage < 10)
            {
                rage++;
            }
        }
        Console.WriteLine($"{Name} is hunting.");
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
);

}