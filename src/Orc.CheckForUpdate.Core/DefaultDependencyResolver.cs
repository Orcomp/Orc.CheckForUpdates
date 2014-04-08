// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultDependencyResolver.cs" company="Orcomp">
//   
// </copyright>
// <summary>
//   Defines the DefaultDependencyResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The default dependency resolver.
    /// </summary>
    public class DefaultDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// The dispose.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Dispose()
        {
            throw new NotImplementedException();
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="activator">
        /// The activator.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Register(Type serviceType, Func<object> activator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="activators">
        /// The activators.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Register(Type serviceType, IEnumerable<Func<object>> activators)
        {
            throw new NotImplementedException();
        }
    }
}
