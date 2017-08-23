using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMaker
{
    public interface IMainViewModel : IViewModel
    {
		IStoryViewModel StoryViewModel { get; set; }

        ICommand New { get; set; }
        ICommand Save { get; set; }
        ICommand Exit { get; set; }
    }
}
