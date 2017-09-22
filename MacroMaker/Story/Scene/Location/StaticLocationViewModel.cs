using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMaker
{
    public class StaticLocationViewModel : NotifyPropertyChanged, ILocationViewModel
    {
        private ILocation _location;
        public ILocation Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public int X
        {
            get { return Location.X; }
            set
            {
                Location.X = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return Location.Y; }
            set
            {
                Location.Y = value;
                OnPropertyChanged("Y");
            }
        }

		public int XPointer { get; set; }
		public int YPointer { get; set; }

		public ICommand ShowCoordinateScreenWindow { get; set; }

		public StaticLocationViewModel()
		{
			ShowCoordinateScreenWindow = new DelegateCommand<object>(ExecuteShowCoordinateScreenWindow);
		}

		private void ExecuteShowCoordinateScreenWindow(object obj)
		{
			var coordinateScreen = new CoordinateScreenWindow();
			coordinateScreen.CoordinateScreenViewModel.LocationViewModel = this;
			coordinateScreen.Show();
		}
    }
}
