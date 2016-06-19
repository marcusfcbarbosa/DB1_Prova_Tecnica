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
using System.Web.Http.Cors;

namespace DB1.Api.Controllers
{

    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("ap1/v1/public")]
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

        [HttpGet]
        [Route("empresas")]
        public Relatorio Get()
        {
            return _repositorioEmpresa.Relatorio();
        }

        [HttpGet]
        [Route("retorna/{id}")]
        public HttpResponseMessage Insere(int id)
        {
            try {

                Empresa emp = new Empresa();
                if (id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, emp);
                }
                return Request.CreateResponse(HttpStatusCode.OK, emp);

            }catch(Exception ex){
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha");
            }
        }

        [HttpPost]
        [Route("atualiza/{empresa}")]
        public void Post([FromBody]Empresa empresa)
        {


        }

        
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {

        }
    }
}