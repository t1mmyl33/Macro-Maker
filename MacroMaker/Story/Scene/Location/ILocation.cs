﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface ILocation
    {
        int X { get; set; }
        int Y { get; set; }

		int getX();
		int getY();
    }
}
