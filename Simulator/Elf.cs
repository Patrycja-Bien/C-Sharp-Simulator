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
    public override char Symbol => 'E';
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
            agility = Validator.Limiter(value, 0, 10);
        }
    }
    public Elf() { }
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
    }

    public override string Greeting() =>
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override string Info 
    {
        get { return $"{Name} [{Level}][{Agility}]"; }
    }
}
