using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.Domain;
using DB1.Domain.Abstract;
using DB1.Domain.Concrete;
using DB1.Domain.Entities;


namespace DB1.Test.Repositorios
{
    [TestClass]
    public class Rel_Empresa_TecnologiaTeste
    {
        #region "Repositorios"
        private IRel_Empresa_Tecnologia repositorioRel_Empresa_Tecnologia;
        private IEmpresa repositorioEmpresa;
        private ITecnologia repositorioTecnologia;
        #endregion
        
        #region "Inicializa os testes"
        /// <summary>
        /// contexto
        /// </summary>
        DB1Context contexto = new DB1Context();
        
        [TestInitialize]
        public void InicializaTeste()
        {
            repositorioRel_Empresa_Tecnologia = new EFRel_Empresa_Tecnologia(contexto);
            repositorioEmpresa = new EFEmpresaRepositorio(contexto);
            repositorioTecnologia = new EFTecnologiaRepositorio(contexto);
        }
        #endregion

        [TestMethod]
        public void LimparRel_Empresa_Tecnologia()
        {
            var Rel_Empresa_Tecnologias = from e in contexto.Rel_Empresa_Tecnologias select e;
            if (Rel_Empresa_Tecnologias.Count() > 0)
            {
                foreach (var Rel_Empresa_Tecnologia in Rel_Empresa_Tecnologias)
                {
                    contexto.Rel_Empresa_Tecnologias.Remove(Rel_Empresa_Tecnologia);
                }
                contexto.SaveChanges();
            }
        }

        [TestMethod]
        public void CargaInicialeTrativaParaConsultasLINQ() {

            var empresa = repositorioEmpresa.BuscaPorCNPJ("02.715.545/0001-00");
            foreach (var tecnologia in repositorioTecnologia.RetornaTodos())
            {
                repositorioRel_Empresa_Tecnologia.Inserir(tecnologia.Tecnologia_ID, empresa.Empresa_ID);
            }
        }

    }
}