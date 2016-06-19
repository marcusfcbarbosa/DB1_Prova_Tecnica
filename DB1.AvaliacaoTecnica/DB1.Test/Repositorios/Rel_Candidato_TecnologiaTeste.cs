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
    public class Rel_Candidato_TecnologiaTeste
    {
        #region "repositorios"
        private IRel_Candidato_Tecnologia repositorioRel_Candidato_Tecnologia;
        private ITecnologia repositorioTecnologia;
        private ICandidato repositorioCandidato;
        #endregion

        #region "Contexto"
        DB1Context contexto = new DB1Context();

        #endregion
        #region "Inicializa Ambiente para testes"
        [TestInitialize]
        public void InicializaTeste()
        {
            repositorioRel_Candidato_Tecnologia = new EFRel_Candidato_Tecnologia(contexto);
            repositorioCandidato = new EFCandidatoRepositorio(contexto);
            repositorioTecnologia = new EFTecnologiaRepositorio(contexto);
        }

        [TestMethod]
        public void LimparRel_Candidato_Tecnologia()
        {
            var Rel_Candidato_Tecnologias = from e in contexto.Rel_Candidato_Tecnologias select e;
            if (Rel_Candidato_Tecnologias.Count() > 0)
            {
                foreach (var Rel_Candidato_Tecnologia in Rel_Candidato_Tecnologias)
                {
                    contexto.Rel_Candidato_Tecnologias.Remove(Rel_Candidato_Tecnologia);
                }
                contexto.SaveChanges();
            }
        }
        #endregion


        [TestMethod]
        public void PodeInserirTodasTecnologiasParaMesmoCandidato()
        {
            var candidato = repositorioCandidato.RetornaPorCPF("158.639.954-32");
            foreach (var tecnologia in repositorioTecnologia.RetornaTodos())
            {
                repositorioRel_Candidato_Tecnologia.Inserir(tecnologia.Tecnologia_ID, candidato.Candidato_ID);
            }
        }

    }
}