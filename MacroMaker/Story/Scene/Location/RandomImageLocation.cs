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
            
        // Randomizes location by -5 / +5 pixels

        private int x;
        public int X
        {
            get { return x + random.Next(-5, 6);  }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y + random.Next(-5, 6); }
            set { y = value; }
        }

        public RandomImageLocation()
        {
            random = new Random();
        }
    }
}
