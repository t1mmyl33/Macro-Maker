﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
	public interface IPlayViewModel : IViewModel
	{
		IStory Story { get; set; }
	}
}
