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
        public int X { get; set; }
        public int Y { get; set; }
		public int XOffset { get; set; }
		public int YOffset { get; set; }
		public bool ContinuousSearch { get; set; }

		public RandomImageLocation()
        {
            random = new Random();
            ImageFile = "";
			ContinuousSearch = false;
		}

		// Randomizes location by -5 / +5 pixels

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
