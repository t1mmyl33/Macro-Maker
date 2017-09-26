using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

		public string RunStyle
		{
			get { return _story.RunStyle; }
			set
			{
				_story.RunStyle = value;
				OnPropertyChanged("RunStyle");
			}
		}

		public int Iterations
		{
			get { return _story.Iterations; }
			set
			{
				_story.Iterations = value;
				OnPropertyChanged("Iterations");
				((DelegateCommand)PlayStory).RaiseCanExecuteChanged();
			}
		}

		public double Duration
		{
			get { return _story.Duration; }
			set
			{
				_story.Duration = value;
				OnPropertyChanged("Duration");
				((DelegateCommand)PlayStory).RaiseCanExecuteChanged();
			}
		}

		private ObservableCollection<ISceneViewModel> _sceneViewModels;
        public ObservableCollection<ISceneViewModel> SceneViewModels
        {
            get
            {
				if (_sceneViewModels == null)
				{
					int cnt = 1;
					_sceneViewModels = new ObservableCollection<ISceneViewModel>(Story.Scenes.Select<IScene, ISceneViewModel>(s => new SceneViewModel() { Index = cnt++, Scene = s }));
				}
					
                return _sceneViewModels;
            }
            set
            {
                _sceneViewModels = value;
                OnPropertyChanged("SceneViewModels");
            }
        }

		private int _currentScene;
		public int CurrentScene
		{
			get { return _currentScene; }
			set
			{
				_currentScene = value;
				OnPropertyChanged("CurrentScene");
			}
		}

		public ICommand AddScene { get; set; }
		public ICommand DeleteScene { get; set; }
		public ICommand MoveSceneUp { get; set; }
		public ICommand MoveSceneDown { get; set; }
		public ICommand PlayStory { get; set; }

        public StoryViewModel()
        {
            Story = new Story();

			AddScene = new DelegateCommand(ExecuteAddScene);
			DeleteScene = new DelegateCommand<ISceneViewModel>(ExecuteDeleteScene);
			MoveSceneUp = new DelegateCommand<ISceneViewModel>(ExecuteMoveSceneUp);
			MoveSceneDown = new DelegateCommand<ISceneViewModel>(ExecuteMoveSceneDown);
			PlayStory = new DelegateCommand(ExecutePlayStory, CanPlayStory);
		}

		private void ExecuteAddScene()
		{
			var scene = new Scene();
			var sceneViewModel = new SceneViewModel { Index = SceneViewModels.Count + 1, Scene = scene };
			Story.Scenes.Add(scene);
			SceneViewModels.Add(sceneViewModel);
		}

		private void ExecuteDeleteScene(ISceneViewModel sceneViewModel)
		{
			SceneViewModels.Remove(sceneViewModel);
			Story.Scenes.Remove(sceneViewModel.Scene);
		}

		private void ExecuteMoveSceneUp(ISceneViewModel sceneViewModel)
		{
			var index = SceneViewModels.IndexOf(sceneViewModel);
			if (index > 0)
			{
				SceneViewModels.Move(index, index - 1);
				SceneViewModels[index].Index++;
				sceneViewModel.Index--;
			}
		}

		private void ExecuteMoveSceneDown(ISceneViewModel sceneViewModel)
		{
			var index = SceneViewModels.IndexOf(sceneViewModel);
			if (index < SceneViewModels.Count - 1)
			{
				SceneViewModels.Move(index, index + 1);
				SceneViewModels[index].Index--;
				sceneViewModel.Index++;
			}
		}

		private bool CanPlayStory()
		{
			if (RunStyle == "Loop" && Iterations > 0)
				return true;
			if (RunStyle == "Time" && Duration > 0)
				return true;
			return false;
		}

		private void ExecutePlayStory()
		{
			//var playWindow = new PlayWindow();
			//playWindow.PlayViewModel.Story = Story;
			//playWindow.Show();

			if (RunStyle == "Loop")
			{
				for (int i = 1; i <= Iterations; i++)
				{
					for (var cnt = 0; cnt < Story.Scenes.Count; cnt++)
					{
						CurrentScene = cnt + 1;
						var scene = Story.Scenes[cnt];

						Thread.Sleep(scene.PreDelay * 1000);
						
						SetCursorPos(scene.Location.getX(), scene.Location.getY());

						Thread.Sleep(scene.PostDelay * 1000);
					}
				}
			}
			else if (RunStyle == "Time")
			{

			}

		}

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetCursorPos(int X, int Y);
	}
}
