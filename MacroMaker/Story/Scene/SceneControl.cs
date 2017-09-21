using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MacroMaker
{
    public class SceneControl : Control
    {
        public static readonly DependencyProperty SceneViewModelProperty = DependencyProperty.Register("SceneViewModel", typeof(ISceneViewModel), typeof(SceneControl), new PropertyMetadata(null));

        public ISceneViewModel SceneViewModel
        {
            get { return (ISceneViewModel)GetValue(SceneViewModelProperty); }
            set { SetValue(SceneViewModelProperty, value); }
        }

		public SceneControl()
		{
		}
    }
}
