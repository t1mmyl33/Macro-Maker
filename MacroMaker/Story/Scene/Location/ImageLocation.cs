using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacroMaker.Story.Scene.Location
{
    public interface ImageLocation : ILocation
    {
        string ImageFile { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}
