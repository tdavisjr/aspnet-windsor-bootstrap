using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using $safeprojectname$.DI.Resolvers;
using System.Web.Http;
using System.Web.Mvc;

namespace $safeprojectname$.DI
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        readonly IWindsorContainer container;

        ContainerBootstrapper(IWindsorContainer container)
        {
            this.container = container;
        }

        public IWindsorContainer Container
        {
            get { return container; }
        }

        public static ContainerBootstrapper Bootstrap()
        {
            return new ContainerBootstrapper(new WindsorContainer()
                .Install(FromAssembly.This()));
        }

        internal void ConfigureResolvers()
        {
            //webapi
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container.Kernel);

            //mvc
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}