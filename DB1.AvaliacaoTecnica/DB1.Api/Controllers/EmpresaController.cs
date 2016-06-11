using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DB1.Domain;
using DB1.Domain.Entities;
using DB1.Domain.Abstract;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace DB1.Api.Controllers
{
    public class EmpresaController : ApiController
    {
        #region "Repositorio"
        private IEmpresa _repositorioEmpresa;
        #endregion

        #region "Injetando as depencias"
        public EmpresaController(IEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }
        #endregion


        // GET: api/Empresa
        public Relatorio Get()
        {
            return _repositorioEmpresa.Relatorio();
        }

        // GET: api/Empresa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empresa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empresa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
        }
    }
}
