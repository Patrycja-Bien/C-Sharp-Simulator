using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description { 
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15,'#');
        }
    }

    public uint Size { get; set; } = 3;

    public override string ToString()
    {
        string DescName = GetType().Name.ToUpper();
        return $"{DescName}: {Info}";
    }

    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
