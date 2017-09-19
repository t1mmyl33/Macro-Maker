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
        private IStoryViewModel _storyViewModel;
        public IStoryViewModel StoryViewModel
        {
            get { return _storyViewModel; }
            set
            {
                _storyViewModel = value;
                OnPropertyChanged("StoryViewModel");
            }
        }

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
            if(MessageBox.Show("Do you want to save current story?", "Save Current Story", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {

            }

			StoryViewModel = new StoryViewModel();
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
