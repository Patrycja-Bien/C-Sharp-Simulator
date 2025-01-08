using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;
    
    [JsonIgnore]
    public override char Symbol => 'O';

    [JsonIgnore]
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
            rage = Validator.Limiter(value, 0, 10);
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
    }
    public override string Greeting() =>
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

    [JsonIgnore]
    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; }
    }

}