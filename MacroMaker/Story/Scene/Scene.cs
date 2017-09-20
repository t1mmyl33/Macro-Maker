using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class Scene : NotifyPropertyChanged, IScene
    {
		private int _preDelay;
        public int PreDelay
		{
			get { return _preDelay; }
			set
			{
				_preDelay = value;
				OnPropertyChanged("PreDelay");
			}
		}

		private int _postDelay;
        public int PostDelay
		{
			get { return _postDelay; }
			set
			{
				_postDelay = value;
				OnPropertyChanged("PostDelay");
			}
		}

		private string _locationType;
		public string LocationType
		{
			get { return _locationType; }
			set
			{
				if (_locationType != value)
				{
					if (value == "Static")
						Location = new StaticLocation();
					else if (value == "Image(center)")
						Location = new CenterImageLocation();
					else if (value == "Image(random)")
						Location = new RandomImageLocation();
					_locationType = value;
					OnPropertyChanged("LocationType");
				}
			}
		}

		private ILocation _location;
        public ILocation Location
		{
			get { return _location; }
			set
			{
				_location = value;
				OnPropertyChanged("Location");
			}
		}

		public Scene()
		{
			LocationType = "Static";
			Location = new StaticLocation();
		}
    }
}
