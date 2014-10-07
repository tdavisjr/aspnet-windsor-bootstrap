using System;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof($safeprojectname$.DI.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof($safeprojectname$.DI.WindsorActivator), "Shutdown")]

namespace $safeprojectname$.DI
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();

            bootstrapper.ConfigureResolvers();
        }
        
        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}