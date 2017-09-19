using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class SceneViewModel : ISceneViewModel
    {
		private static List<string> _locationType = new List<string> { "Static", "Image(center)", "Image(random)" };
		public List<string> LocationType
		{
			get { return _locationType; }
		}

        public IScene Scene { get; set; }

        public SceneViewModel()
        {

        }
    }
}
