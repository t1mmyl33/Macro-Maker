using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMaker
{
    public interface IStoryViewModel : IViewModel
    {
        IStory Story { get; set; }
		string RunStyle { get; set; }
		int Iterations { get; set; }
		double Duration { get; set; }
		ICommand AddScene { get; set; }
		ICommand DeleteScene { get; set; }
		ICommand MoveSceneUp { get; set; }
		ICommand MoveSceneDown { get; set; }
		ObservableCollection<ISceneViewModel> SceneViewModels { get; set; }
    }
}
