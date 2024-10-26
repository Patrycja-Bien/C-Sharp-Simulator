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
            description = value.Trim();
            if (description.Length > 15)
            {
                description = description.Substring(0, 15).Trim();
            }
            if (description.Length < 3)
            {
                int missing = 3 - description.Length;
                string hash = String.Concat(Enumerable.Repeat("#", missing));
                description = $"{description}{hash}";
            }
            if (char.IsLower(description[0]))
            {
                description = char.ToUpper(description[0]) + description.Substring(1);
            }
        }
    }

    private uint size = 3;
    public uint Size { get; set; }

    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
