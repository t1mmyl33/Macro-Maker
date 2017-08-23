using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface ISceneViewModel : IViewModel
    {
        IScene Scene { get; set; }

    }
}
