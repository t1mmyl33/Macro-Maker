using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MacroMaker
{
	/// <summary>
	/// Interaction logic for CoordinateScreenWindow.xaml
	/// </summary>
	public partial class CoordinateScreenWindow : Window
	{
		public ICoordinateScreenViewModel CoordinateScreenViewModel { get; set; }

		public double XSize { get; set; } = SystemParameters.PrimaryScreenHeight;

		public int YSize { get; set; } = 400;

		public CoordinateScreenWindow()
		{
			CoordinateScreenViewModel = IoC.Resolve<ICoordinateScreenViewModel>();

			InitializeComponent();
		}
	}
}
