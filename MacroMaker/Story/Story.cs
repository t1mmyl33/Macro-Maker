using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class Story : NotifyPropertyChanged, IStory
    {
        private int _iterations;
        public int Iterations
        {
            get { return _iterations; }
            set
            {
                _iterations = value;
                OnPropertyChanged("Iterations");
            }
        }

        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private string _runStyle;
        public string RunStyle
        {
            get { return _runStyle; }
            set
            {
                _runStyle = value;
                OnPropertyChanged("RunStyle");
            }
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

		public Story()
		{
            RunStyle = "Loop";
            Scenes = new List<IScene>();

            var scene1 = new Scene();
            scene1.PreDelay = 5;
            scene1.PostDelay = 10;
			scene1.LocationType = "Image(center)";

			var scene2 = new Scene();
			scene2.PreDelay = 15;
			scene2.PostDelay = 20;
			scene2.LocationType = "Image(center)";

			Scenes.Add(scene1);
			Scenes.Add(scene2);
		}
    }
}
