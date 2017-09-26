using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

		public bool ContinuousSearch
		{
			get { return ((RandomImageLocation)Location).ContinuousSearch; }
			set
			{
				((RandomImageLocation)Location).ContinuousSearch = value;
				OnPropertyChanged("ContinuousSearch");
			}
		}

		public string ImageFile
		{
			get { return ((RandomImageLocation)Location).ImageFile; }
			set
			{
				((RandomImageLocation)Location).ImageFile = value;
				OnPropertyChanged("ImageFile");
				OnPropertyChanged("ImageFileName");
			}
		}
		public string ImageFileName
		{
			get
			{
				if (ImageFile == null)
					return "";
				return Path.GetFileName(((RandomImageLocation)Location).ImageFile);
			}
		}

		public ICommand BrowseForImage { get; set; }

		public RandomImageLocationViewModel()
		{
			BrowseForImage = new DelegateCommand<object>(ExecuteBrowseForImage);
		}

		private void ExecuteBrowseForImage(object obj)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == true)
			{
				ImageFile = dlg.FileName;
			}
		}

	}
}
