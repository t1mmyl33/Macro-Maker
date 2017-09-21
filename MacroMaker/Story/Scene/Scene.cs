using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class Scene : IScene
    {
		private int _preDelay;
        public int PreDelay
		{
			get { return _preDelay; }
            set { _preDelay = value; }
		}

		private int _postDelay;
        public int PostDelay
		{
			get { return _postDelay; }
            set { _postDelay = value; }
		}

		private string _locationType;
		public string LocationType
		{
			get { return _locationType; }
            set { _locationType = value; }
		}

		private ILocation _location;
        public ILocation Location
		{
			get { return _location; }
            set { _location = value; }
		}

		public Scene()
		{
            LocationType = "Image(center)";
			Location = new CenterImageLocation();
		}
    }
}
