using MacroMaker.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMaker
{
    public class MainViewModel : IMainViewModel
    {
        public IStory Story { get; set; }

        public ICommand New { get; set; }
        public ICommand Save { get; set; }
        public ICommand Exit { get; set; }

        public MainViewModel()
        {

        }
    }
}
