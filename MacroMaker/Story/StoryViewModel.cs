using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class StoryViewModel : IStoryViewModel
    {
        public IStory Story { get; set; }
    }
}
