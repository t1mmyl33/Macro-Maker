using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacroMaker
{
    public class CenterImageLocation : ImageLocation
    {
        public string ImageFile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int XOffset { get; set; }
		public int YOffset { get; set; }
		public bool ContinuousSearch { get; set; }

		public CenterImageLocation()
        {
            ImageFile = "";
			ContinuousSearch = false;
        }

		public int getX()
		{
			return X + XOffset;
		}

		public int getY()
		{
			return Y + YOffset;
		}
	}
}
