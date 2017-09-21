using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class RandomImageLocationViewModel : NotifyPropertyChanged, ILocationViewModel
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

        public int XOffset
        {
            get { return ((RandomImageLocation)Location).XOffset; }
            set
            {
                ((RandomImageLocation)Location).XOffset = value;
                OnPropertyChanged("XOffset");
            }
        }

        public int YOffset
        {
            get { return ((RandomImageLocation)Location).YOffset; }
            set
            {
                ((RandomImageLocation)Location).YOffset = value;
                OnPropertyChanged("YOffset");
            }
        }
    }
}
