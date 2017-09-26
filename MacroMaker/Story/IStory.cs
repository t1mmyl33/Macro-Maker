using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface IStory
    {
		string RunStyle { get; set; }
		int Iterations { get; set; }
		double Duration { get; set; }
        List<IScene> Scenes { get; set; }
    }
}
