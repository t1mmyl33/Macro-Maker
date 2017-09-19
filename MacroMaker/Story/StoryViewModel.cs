using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class StoryViewModel : NotifyPropertyChanged, IStoryViewModel
    {
        private List<string> _styles = new List<string> { "Loop", "Time" };
        public List<string> Styles
        {
            get { return _styles; }
        }

        private IStory _story;
        public IStory Story
        {
            get { return _story; }
            set
            {
                _story = value;
                OnPropertyChanged("Story");
            }
        }

        public StoryViewModel()
        {
            Story = new Story();
        }
    }
}
