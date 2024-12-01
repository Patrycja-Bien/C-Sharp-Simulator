using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds: Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol
    {
        get
        {
            return CanFly ? 'B' : 'b';
        }
    }


    public override string Info
    {
        get
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }


    }
}

