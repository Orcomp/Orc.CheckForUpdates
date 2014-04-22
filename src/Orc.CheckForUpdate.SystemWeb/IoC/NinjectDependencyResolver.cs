// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="Orcomp">
//   No copyright http://www.peterprovost.org/blog/2012/06/19/adding-ninject-to-web-api/
// </copyright>
// <summary>
//   Defines the NinjectDependencyResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.IoC
{
    using System.Web.Http.Dependencies;

    using Ninject;

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        /// <summary>
        /// The kernel.
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}
