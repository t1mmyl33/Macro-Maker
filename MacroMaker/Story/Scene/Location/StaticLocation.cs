using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public class StaticLocation : ILocation
    {
        public int X { get; set; }
        public int Y { get; set; }

		public int getX()
		{
			return X;
		}

		public int getY()
		{
			return Y;
		}
	}
}
