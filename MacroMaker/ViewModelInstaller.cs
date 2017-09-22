using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;

namespace MacroMaker
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModel>().LifestyleSingleton());
			container.Register(Component.For<IStoryViewModel>().ImplementedBy<StoryViewModel>().LifestyleSingleton());
			container.Register(Component.For<ICoordinateScreenViewModel>().ImplementedBy<CoordinateScreenViewModel>().LifestyleSingleton());
		}
    }
}
