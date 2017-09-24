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
    public class CenterImageLocationViewModel : NotifyPropertyChanged, ILocationViewModel
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
            get { return ((CenterImageLocation)Location).XOffset; }
            set
            {
                ((CenterImageLocation)Location).XOffset = value;
                OnPropertyChanged("XOffset");
            }
        }

        public int YOffset
        {
            get { return ((CenterImageLocation)Location).YOffset; }
            set
            {
                ((CenterImageLocation)Location).YOffset = value;
                OnPropertyChanged("YOffset");
            }
        }

		public string ImageFile
		{
            //get { return Path.GetFileName(((CenterImageLocation)Location).ImageFile); }
            get { return ((CenterImageLocation)Location).ImageFile; }
			set
			{
				((CenterImageLocation)Location).ImageFile = value;
                Temp = @"C:\Users\Timmy\Desktop\BackUp to Reformatted\Photos\Picture Folder\misc\84256.jpg";
				OnPropertyChanged("ImageFile");
			}
		}

		public ICommand BrowseForImage { get; set; }

		public CenterImageLocationViewModel()
		{
			BrowseForImage = new DelegateCommand<object>(ExecuteBrowseForImage);

            Temp = "";
		}

		private void ExecuteBrowseForImage(object obj)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == true)
			{
				ImageFile = dlg.FileName;
			}
		}

        private string _temp;
        public string Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged("Temp");
            }
        }
    }
}
