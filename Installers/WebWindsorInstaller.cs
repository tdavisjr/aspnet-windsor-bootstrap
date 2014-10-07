using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace $safeprojectname$.DI.Installers
{
    using Resolvers;
    using System.Web.Http;

    public class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //MVC
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());


            //TODO: WEB API
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<ApiController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());
        }
    }
}