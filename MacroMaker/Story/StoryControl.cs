using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MacroMaker
{
    public class StoryControl : Control
    {
		public static readonly DependencyProperty StoryViewModelProperty = DependencyProperty.Register("StoryViewModel", typeof(IStoryViewModel), typeof(StoryControl), new PropertyMetadata(null));

		public IStoryViewModel StoryViewModel
		{
			get { return (IStoryViewModel)GetValue(StoryViewModelProperty); }
			set { SetValue(StoryViewModelProperty, value); }
		}
    }
}
