using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Syntax;
using DB1.Domain.Entities;
using DB1.Domain.Abstract;
using DB1.Domain.Concrete;
using Ninject.WebApi.DependencyResolver;


namespace DB1.Api
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public IKernel Kernel { get { return kernel; } }

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();

        }
        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        private void AddBindings()
        {
            Bind<IInscricao>().To<EFInscricao>();
            Bind<IEmpresa>().To<EFEmpresaRepositorio>();
            Bind<ICandidato>().To<EFCandidatoRepositorio>();
            Bind<ITecnologia>().To<EFTecnologiaRepositorio>();
            Bind<IRel_Candidato_Tecnologia>().To<EFRel_Candidato_Tecnologia>();
            Bind<IRel_Empresa_Tecnologia>().To<EFRel_Empresa_Tecnologia>();
            Bind<DB1Context>().ToSelf();

        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}