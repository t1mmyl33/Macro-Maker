using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
			if (ContinuousSearch)
			{
				while (!SearchImagePoint())
				{
					Thread.Sleep(5000);
				}
			}

			return X + XOffset;
		}

		public int getY()
		{
			return Y + YOffset;
		}

		private Point SearchImagePoint()
		{
			var screenBitmap = BitmapUtility.GetScreenBitmap();
			var searchBitmap = new Bitmap(ImageFile);
			var possiblePoints = BitmapUtility.GetSubPositions(screenBitmap, searchBitmap);

			if (possiblePoints.Count == 0)
				return false;

			var searchHeight = searchBitmap.Height;
			var searchWidth = searchBitmap.Width;

			X = possiblePoints[0].X + searchHeight / 2;
			Y = possiblePoints[0].Y + searchWidth / 2;

			return true;
		}
	}
}
