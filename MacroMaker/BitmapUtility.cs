﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MacroMaker
{
	public static class BitmapUtility
	{
		public static Bitmap GetScreenBitmap()
		{
			var screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
										Screen.PrimaryScreen.Bounds.Height,
										PixelFormat.Format32bppArgb);

			var screenGraphics = Graphics.FromImage(screenBitmap);

			screenGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
													Screen.PrimaryScreen.Bounds.Y,
													0, 0,
													Screen.PrimaryScreen.Bounds.Size,
													CopyPixelOperation.SourceCopy);

			return screenBitmap;
		}

		public static Point GetSubPositions(Bitmap main, Bitmap sub)
		{
			List<Point> possiblepos = new List<Point>();

			int mainwidth = main.Width;
			int mainheight = main.Height;

			int subwidth = sub.Width;
			int subheight = sub.Height;

			int movewidth = mainwidth - subwidth;
			int moveheight = mainheight - subheight;

			BitmapData bmMainData = main.LockBits(new Rectangle(0, 0, mainwidth, mainheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			BitmapData bmSubData = sub.LockBits(new Rectangle(0, 0, subwidth, subheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

			int bytesMain = Math.Abs(bmMainData.Stride) * mainheight;
			int strideMain = bmMainData.Stride;
			System.IntPtr Scan0Main = bmMainData.Scan0;
			byte[] dataMain = new byte[bytesMain];
			System.Runtime.InteropServices.Marshal.Copy(Scan0Main, dataMain, 0, bytesMain);

			int bytesSub = Math.Abs(bmSubData.Stride) * subheight;
			int strideSub = bmSubData.Stride;
			System.IntPtr Scan0Sub = bmSubData.Scan0;
			byte[] dataSub = new byte[bytesSub];
			System.Runtime.InteropServices.Marshal.Copy(Scan0Sub, dataSub, 0, bytesSub);

			var zeroColor = MyColor.FromARGB(0, 0, 0, 0);

			for (int y = 0; y < mainheight; ++y)
			{
				for (int x = 0; x < mainwidth; ++x)
				{
					MyColor curcolor = GetColor(x, y, strideMain, dataMain);

					foreach (var item in possiblepos.ToArray())
					{
						int xsub = x - item.X;
						int ysub = y - item.Y;
						if (xsub >= subwidth || ysub >= subheight || xsub < 0)
							continue;

						MyColor subcolor = GetColor(xsub, ysub, strideSub, dataSub);

						if (!curcolor.Equals(subcolor) && !curcolor.Equals(zeroColor))
						{
							possiblepos.Remove(item);
						}
					}

					if (x >= movewidth || y >= movewidth)
						continue;

					if (curcolor.Equals(GetColor(0, 0, strideSub, dataSub)))
						possiblepos.Add(new Point(x, y));
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(dataSub, 0, Scan0Sub, bytesSub);
			sub.UnlockBits(bmSubData);

			System.Runtime.InteropServices.Marshal.Copy(dataMain, 0, Scan0Main, bytesMain);
			main.UnlockBits(bmMainData);

			if (possiblepos.Count == 0)
				return null;
			return possiblepos[0];
		}

		private static MyColor GetColor(Point point, int stride, byte[] data)
		{
			return GetColor(point.X, point.Y, stride, data);
		}

		private static MyColor GetColor(int x, int y, int stride, byte[] data)
		{
			int pos = y * stride + x * 4;
			byte a = data[pos + 3];
			byte r = data[pos + 2];
			byte g = data[pos + 1];
			byte b = data[pos + 0];
			return MyColor.FromARGB(a, r, g, b);
		}

		struct MyColor
		{
			byte A;
			byte R;
			byte G;
			byte B;

			public static MyColor FromARGB(byte a, byte r, byte g, byte b)
			{
				MyColor mc = new MyColor();
				mc.A = a;
				mc.R = r;
				mc.G = g;
				mc.B = b;
				return mc;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is MyColor))
					return false;
				MyColor color = (MyColor)obj;
				if (color.A == this.A && color.R == this.R && color.G == this.G && color.B == this.B)
					return true;
				return false;
			}
		}
	}
}
