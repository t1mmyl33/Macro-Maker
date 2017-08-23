using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface IScene
    {
        int PreDelay { get; set; }
        int PostDelay { get; set; }
        ILocation Location { get; set; }
    }
}
