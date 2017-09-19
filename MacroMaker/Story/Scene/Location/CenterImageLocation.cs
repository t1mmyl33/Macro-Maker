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

		private int _x;
        public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		private int _y;
        public int Y
		{
			get { return _y; }
			set { _y = value; }
		}

		private int _xoffset;
		public int XOffset { get; set; }

		private int _yoffset;
		public int YOffset { get; set; }

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
