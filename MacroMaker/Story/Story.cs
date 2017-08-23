using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class Story : IStory
    {
        public List<IScene> Scenes { get; set; }

		public Story()
		{

		}
    }
}
