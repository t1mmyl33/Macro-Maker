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

		private ISceneViewModel _sceneViewModel;
		public ISceneViewModel SceneViewModel
		{
			get { return _sceneViewModel; }
			set
			{
				_sceneViewModel = value;
				OnPropertyChanged("SceneViewModel");
			}
		}

        public StoryViewModel()
        {
            Story = new Story();

			SceneViewModel = IoC.Resolve<ISceneViewModel>();
			SceneViewModel.Scenes = Story.Scenes;
        }
    }
}
