using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface ISceneViewModel : IViewModel
    {
		int Index { get; set; }
        IStoryViewModel StoryViewModel { get; set; }
        ILocationViewModel LocationViewModel { get; set; }
        IScene Scene { get; set; }
    }
}
