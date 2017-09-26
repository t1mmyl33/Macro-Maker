using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacroMaker
{
    public interface ImageLocation : ILocation
    {
        string ImageFile { get; set; }
		int XOffset { get; set; }
		int YOffset { get; set; }
		bool ContinuousSearch { get; set; }
    }
}
