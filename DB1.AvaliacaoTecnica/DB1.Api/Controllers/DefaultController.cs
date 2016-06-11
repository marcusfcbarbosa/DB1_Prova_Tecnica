using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DB1.Domain;
using DB1.Domain.Abstract;
using Ninject;

namespace DB1.Api.Controllers
{
    public class DefaultController : ApiController
    {
        #region "Repositorios"
        private IInscricao _repositorioInscricao;
        private IEmpresa _repositorioEmpresa;
        private ICandidato _repositorioCandidato;
        private ITecnologia _repositorioTecnologia;
        private IRel_Candidato_Tecnologia _repositorioRel_Candidato_Tecnologia;
        private IRel_Empresa_Tecnologia _repositorioRel_Empresa_Tecnologia;
        #endregion


        #region "Injetando as depencias"
        public DefaultController(IInscricao repositorioInscricao, IEmpresa repositorioEmpresa,
            ICandidato repositorioCandidato, ITecnologia repositorioTecnologia,
            IRel_Candidato_Tecnologia repositorioRel_Candidato_Tecnologia,
            IRel_Empresa_Tecnologia repositorioRel_Empresa_Tecnologia)
        {
            _repositorioInscricao = repositorioInscricao;
            _repositorioEmpresa = repositorioEmpresa;
            _repositorioCandidato = repositorioCandidato;
            _repositorioRel_Candidato_Tecnologia = repositorioRel_Candidato_Tecnologia;
            _repositorioTecnologia = repositorioTecnologia;
            _repositorioRel_Empresa_Tecnologia = repositorioRel_Empresa_Tecnologia;
        }
        #endregion

        // GET: api/Get
        public IEnumerable<Object> Get()
        {
            return _repositorioEmpresa.RetornaTodos();
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
