using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface IStoryViewModel : IViewModel
    {
		ISceneViewModel SceneViewModel { get; set; }

        IStory Story { get; set; }
    }
}
