using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface IStory
    {
        int Iterations { get; set; }
        int Duration { get; set; }
        string RunStyle { get; set; }
        List<IScene> Scenes { get; set; }
    }
}
