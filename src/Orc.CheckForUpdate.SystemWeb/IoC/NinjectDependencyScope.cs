namespace Orc.CheckForUpdate.Web.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using Ninject;
    using Ninject.Syntax;

    /// <summary>
    /// Provides a Ninject implementation of IDependencyScope which resolves services using the Ninject container.
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The resolver.
        /// </summary>
        private IResolutionRoot resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyScope"/> class.
        /// </summary>
        /// <param name="resolver">
        /// The resolver.
        /// </param>
        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// </exception>
        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return this.resolver.TryGet(serviceType);
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// </exception>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return this.resolver.GetAll(serviceType);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            IDisposable disposable = this.resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.resolver = null;
        }
    }
}
