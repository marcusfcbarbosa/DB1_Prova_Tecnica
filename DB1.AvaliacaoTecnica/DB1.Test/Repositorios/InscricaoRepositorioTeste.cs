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
    public class InscricaoRepositorioTeste
    {
        #region "Repositorios"
        private IInscricao respositorioInscricao;
        private IEmpresa repositorioEmpresa;
        private ITecnologia repositorioTecnologia;
        private ICandidato repositorioCandidato;
        #endregion

        #region "Inicializa os testes"
        DB1Context contexto = new DB1Context();

        [TestInitialize]
        public void InicializaTeste()
        {
            respositorioInscricao = new EFInscricao(contexto);
            repositorioEmpresa = new EFEmpresaRepositorio(contexto);
            repositorioTecnologia = new EFTecnologiaRepositorio(contexto);
            repositorioCandidato = new EFCandidatoRepositorio(contexto);
        }
        [TestMethod]
        public void LimpaInscricoes()
        {
            var inscricoes = from e in contexto.Inscricoes select e;
            if (inscricoes.Count() > 0)
            {
                foreach (var inscricao in inscricoes)
                {
                    contexto.Inscricoes.Remove(inscricao);
                }
                contexto.SaveChanges();
            }
        }
        #endregion

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirAMesmaPessoaParaAMesmaEmpresaMaisDeUmaVezTeste()
        {
            var empresa = repositorioEmpresa.BuscaPorCNPJ("02.715.545/0001-00");
            var candidato = repositorioCandidato.RetornaPorCPF("158.639.954-32");
            var tecnologida = repositorioTecnologia.retornaPorDescricao("Plataforma ASP.Net");
            respositorioInscricao.Inserir(candidato.Candidato_ID, empresa.Empresa_ID, tecnologida.Tecnologia_ID);
            respositorioInscricao.Inserir(candidato.Candidato_ID, empresa.Empresa_ID, tecnologida.Tecnologia_ID);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirMaisDeUmaInscricaoSeUltrapassarNumeroDeVagasTeste()
        {
            var empresa = repositorioEmpresa.BuscaPorCNPJ("02.715.545/0001-00");
            var candidato = repositorioCandidato.RetornaPorCPF("971.178.885-39");
            var tecnologida = repositorioTecnologia.retornaPorDescricao("Plataforma ASP.Net");
            respositorioInscricao.Inserir(candidato.Candidato_ID, empresa.Empresa_ID, tecnologida.Tecnologia_ID);
        }
    }
}