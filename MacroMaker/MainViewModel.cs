using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MacroMaker
{
    public class MainViewModel : NotifyPropertyChanged, IMainViewModel
	{
        public IStoryViewModel StoryViewModel { get; set; }

        public ICommand New { get; set; }
        public ICommand Save { get; set; }
        public ICommand Exit { get; set; }

        public MainViewModel()
        {
			New = new DelegateCommand<object>(ExecuteCreateNewStory);
			Save = new DelegateCommand<object>(ExecuteSaveCurrentStory);
			Exit = new DelegateCommand<Window>(Close);
        }

		public void ExecuteCreateNewStory(object obj)
		{
			StoryViewModel = new StoryViewModel();
			StoryViewModel.Story = new Story();
		}

		public void ExecuteSaveCurrentStory(object obj)
		{

		}

		public void Close(Window window)
		{
			window.Close();
		}
    }
}
