using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public interface ILocationViewModel : IViewModel
    {
        ILocation Location { get; set; }
		int X { get; set; }
		int Y { get; set; }
    }
}
