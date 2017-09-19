using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace MacroMaker
{
    [Serializable]
    public class RandomImageLocation : ImageLocation
    {
        [XmlIgnore]
        private Random random;

        public string ImageFile { get; set; }
            
        // Randomizes location by -5 / +5 pixels

        private int _x;
        public int X
        {
            get { return _x;  }
            set { _x = value; }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

		private int _xoffset;
		public int XOffset
		{
			get { return _xoffset; }
			set { _xoffset = value; }
		}

		private int _yoffset;
		public int YOffset
		{
			get { return _yoffset; }
			set { _yoffset = value; }
		}

		public RandomImageLocation()
        {
            random = new Random();
        }

		public int getX()
		{
			return X + XOffset + random.Next(-5, 6);
		}

		public int getY()
		{
			return Y + YOffset + random.Next(-5, 6);
		}
	}
}
