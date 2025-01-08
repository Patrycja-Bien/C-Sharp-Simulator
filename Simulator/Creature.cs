using Simulator.Maps;
using System;
using System.Text.Json.Serialization;

namespace Simulator;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
public abstract class Creature : IMappable
{
    private string name = "Unknown";
    public Map? Map { get; set; }
    public Point Position { get; set; }

    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }
    public abstract char Symbol { get; }
    protected Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public abstract string Greeting();

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }

    public override string ToString()
    {
        string creatureName = GetType().Name.ToUpper();
        return $"{creatureName}: {Info}";
    }

    public abstract string Info { get; }
}
