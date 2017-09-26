using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MacroMaker
{
	public class PlayViewModel : NotifyPropertyChanged, IPlayViewModel
	{
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
	}
}
