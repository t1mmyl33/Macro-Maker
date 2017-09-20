using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class SceneViewModel : NotifyPropertyChanged, ISceneViewModel
    {
		private static List<string> _locationType = new List<string> { "Static", "Image(center)", "Image(random)" };
		public List<string> LocationType
		{
			get { return _locationType; }
		}

		private List<IScene> _scenes;
        public List<IScene> Scenes
		{
			get { return _scenes; }
			set
			{
				_scenes = value;
				OnPropertyChanged("Scenes");
			}
		}

        public SceneViewModel()
        {
			Scenes = new List<IScene>();
        }
    }
}
