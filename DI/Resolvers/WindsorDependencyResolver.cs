using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace $safeprojectname$.DI.Resolvers
{
    /// <summary>
    /// This is used by WebAPI. All dependencies registered for Windsor will
    /// call into this class.
    /// </summary>
    internal class WindsorDependencyResolver : IDependencyResolver
    {
        private Castle.MicroKernel.IKernel container;

        public WindsorDependencyResolver(Castle.MicroKernel.IKernel container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        public object GetService(Type serviceType)
        {
            return this.container.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose() 
        {
            container.Dispose();
            container = null;
        }
    }
}
