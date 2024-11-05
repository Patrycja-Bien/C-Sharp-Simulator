using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Elf : Creature
{
    private int singCount = 0;

    public override int Power
    {
        get { return (8 * Level + 2 * Agility); }
    }

    private int agility;
    public int Agility
    {
        get { return agility; }
        init
        {
            if (value < 1)
            {
                agility = 1;
            }
            else if (value > 10)
            {
                agility = 10;
            }
            else
            {
                agility = value;
            }
        }
    }
    public Elf() {}
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public void Sing()
    {
        singCount++;
        if (singCount % 3 == 0)
        {
            if (agility < 10)
            {
                agility++;
            }
        }
        Console.WriteLine($"{Name} is singing.");
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);
}
