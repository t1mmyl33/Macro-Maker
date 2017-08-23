using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMaker
{
    public static class IoC
    {
        private static IWindsorContainer _container;

        public static void Initialize()
        {
            _container = new WindsorContainer();

            Register();
        }

        private static void Register()
        {
            _container.Install(FromAssembly.This());
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
