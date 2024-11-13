using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value,3,25,'#');
        }
    }

    private int level = 1;
    public int Level 
    { 
        get {  return level; }
        set
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {

    }
    public abstract string Greeting();

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    //{
    //    string dir = direction.ToString();
    //Console.WriteLine($"{Name} goes {char.ToLower(dir[0])+dir.Substring(1)}.");
    //}
    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i = 0; i<directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public string[] Go(string directions)
    {
        return Go(DirectionParser.Parse(directions));
    }

    public void Upgrade()
    {
        if ( Level < 10 )
        {
            level++;
        }
    }

    public override string ToString()
    {
        string creatureName = GetType().Name.ToUpper();
        return $"{creatureName}: {Info}";
    }
    public abstract string Info { get; }
}
