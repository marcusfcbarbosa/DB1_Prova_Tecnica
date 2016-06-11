[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DB1.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DB1.Api.App_Start.NinjectWebCommon), "Stop")]

namespace DB1.Api.App_Start
{
    using System;
    using System.Web;
    using DB1.Domain;
    using DB1.Domain.Entities;
    using DB1.Domain.Abstract;
    using DB1.Domain.Concrete;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmpresa>().To<EFEmpresaRepositorio>().InRequestScope();
            kernel.Bind<IInscricao>().To<EFInscricao>().InRequestScope();
            kernel.Bind<ICandidato>().To<EFCandidatoRepositorio>().InRequestScope();
            kernel.Bind<ITecnologia>().To<EFTecnologiaRepositorio>().InRequestScope();
            kernel.Bind<IRel_Candidato_Tecnologia>().To<EFRel_Candidato_Tecnologia>().InRequestScope();
            kernel.Bind<IRel_Empresa_Tecnologia>().To<EFRel_Empresa_Tecnologia>().InRequestScope();
        }        
    }
}
