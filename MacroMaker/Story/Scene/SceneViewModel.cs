using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class SceneViewModel : NotifyPropertyChanged, ISceneViewModel
    {
		private static List<string> _locationTypes = new List<string> { "Static", "Image(center)", "Image(random)" };
		public List<string> LocationTypes
		{
			get { return _locationTypes; }
		}

		private int _index;
		public int Index
		{
			get { return _index; }
			set
			{
				_index = value;
				OnPropertyChanged("Index");
			}
		}

        public IStoryViewModel StoryViewModel { get; set; }

        private ILocationViewModel _locationViewModel;
        public ILocationViewModel LocationViewModel
        {
            get { return _locationViewModel; }
            set
            {
                _locationViewModel = value;
                OnPropertyChanged("LocationViewModel");
            }
        }

        private IScene _scene;
        public IScene Scene
        {
            get { return _scene; }
            set
            {
                _scene = value;
                OnPropertyChanged("Scene");
            }
        }

        public int PreDelay
        {
            get { return Scene.PreDelay; }
            set
            {
                Scene.PreDelay = value;
                OnPropertyChanged("PreDelay");
            }
        }

        public int PostDelay
        {
            get { return Scene.PostDelay; }
            set
            {
                Scene.PostDelay = value;
                OnPropertyChanged("PostDelay");
            }
        }

        public string LocationType
        {
            get { return Scene.LocationType; }
            set
            {
                if (Scene.LocationType != value)
                {
                    if (value == "Static")
                    {
                        Scene.Location = new StaticLocation();
                        LocationViewModel = new StaticLocationViewModel()
                        {
                            Location = Scene.Location
                        };
                    }
                    else if (value == "Image(center)")
                    {
                        Scene.Location = new CenterImageLocation();
                        LocationViewModel = new CenterImageLocationViewModel()
                        {
                            Location = Scene.Location
                        };
                    }
                    else if (value == "Image(random)")
                    {
                        Scene.Location = new RandomImageLocation();
                        LocationViewModel = new RandomImageLocationViewModel()
                        {
                            Location = Scene.Location
                        };
                    } 

                    Scene.LocationType = value;
                    OnPropertyChanged("LocationType");
                }
            }
        }

        public ILocation Location
        {
            get { return Scene.Location; }
        }

        public SceneViewModel()
        {
            Scene = new Scene();
            LocationViewModel = new CenterImageLocationViewModel() { Location = Scene.Location };
        }
    }
}
