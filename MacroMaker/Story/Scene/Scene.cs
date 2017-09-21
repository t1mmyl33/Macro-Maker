using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class Scene : IScene
    {
        public int PreDelay { get; set; }
        public int PostDelay { get; set; }
        public ILocation Location { get; set; }
    }
}
