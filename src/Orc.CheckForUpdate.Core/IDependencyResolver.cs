// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependencyResolver.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IDependencyResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The DependencyResolver interface.
    /// </summary>
    public interface IDependencyResolver : IDisposable
    {
        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object GetService(Type serviceType);

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<object> GetServices(Type serviceType);

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="activator">
        /// The activator.
        /// </param>
        void Register(Type serviceType, Func<object> activator);

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="activators">
        /// The activators.
        /// </param>
        void Register(Type serviceType, IEnumerable<Func<object>> activators);
    }
}