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
	public class CoordinateScreenViewModel : ICoordinateScreenViewModel
	{
		public ILocationViewModel LocationViewModel { get; set; }
		public ICommand SelectCoordinates { get; set; }
		public ICommand CancelSelector { get; set; }

		public CoordinateScreenViewModel()
		{
			SelectCoordinates = new DelegateCommand<Window>(ExecuteSelectCoordinates);
			CancelSelector = new DelegateCommand<Window>(ExecuteCancelSelector);
		}

		private void ExecuteSelectCoordinates(Window window)
		{
			var cursorPosition = GetCursorPosition();

			LocationViewModel.X = (int)cursorPosition.X;
			LocationViewModel.Y = (int)cursorPosition.Y;
			window.Close();
		}

		private void ExecuteCancelSelector(Window window)
		{
			window.Close();
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public static implicit operator Point(POINT point)
			{
				return new Point(point.X, point.Y);
			}
		}

		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out POINT lpPoint);

		public static Point GetCursorPosition()
		{
			POINT lpPoint;
			GetCursorPos(out lpPoint);

			return lpPoint;
		}
	}
}
