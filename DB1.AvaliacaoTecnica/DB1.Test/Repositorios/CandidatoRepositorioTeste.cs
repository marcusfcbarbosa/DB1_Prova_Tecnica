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
    public class CandidatoRepositorioTeste
    {
        /// <summary>
        /// Repositorio Candidato
        /// </summary>
        private ICandidato candidatoRepositorio;

        /// <summary>
        /// contexto
        /// </summary>
        DB1Context contexto = new DB1Context();

        [TestInitialize]
        public void InicializaTeste() {
            candidatoRepositorio = new EFCandidatoRepositorio(contexto);
        }

        [TestMethod]
        public void LimparCandidatos() {

            var candidatos = from c in contexto.Candidatos select c;
            if (candidatos.Count() > 0) {
                foreach (var candidato in candidatos) {
                    contexto.Candidatos.Remove(candidato);
                }
                contexto.SaveChanges();
            }
        }


        [TestMethod]
        public void CargaInicialDeCandidatoseTrativaParaConsultasLINQ() { 
            ///Ambiente
            var candidatoInserir = new Candidato {
                Cpf = "158.639.954-32",
                Email ="marcusfcbarbosa@hotmail.com",
                Idade = 30,
                Nome ="Marcus Fernando Correa Barbosa",
                Status = true,
                Telefone="(11) 9 8660-2829",
                Data_Registro = DateTime.Now
            };

            contexto.Candidatos.Add(candidatoInserir);

            var candidatoInserir2 = new Candidato
            {
                Cpf = "971.178.885-39",
                Email = "marcusfcbarbosa2@hotmail.com",
                Idade = 30,
                Nome = "Marcus Fernando Correa Barbosa 2",
                Status = true,
                Telefone = "(11) 9 8660-2829",
                Data_Registro = DateTime.Now
            };

            contexto.Candidatos.Add(candidatoInserir2);

            var candidatoInserir3 = new Candidato
            {
                Cpf = "245.439.235-61",
                Email = "marcusfcbarbosa3@hotmail.com",
                Idade = 30,
                Nome = "Marcus Fernando Correa Barbosa 3",
                Status = true,
                Telefone = "(11) 9 8660-2829",
                Data_Registro = DateTime.Now
            };

            contexto.Candidatos.Add(candidatoInserir3);

            var candidatoInserir4 = new Candidato
            {
                Cpf = "269.097.041-42",
                Email = "marcusfcbarbosa4@hotmail.com",
                Idade = 30,
                Nome = "Marcus Fernando Correa Barbosa 4",
                Status = true,
                Telefone = "(11) 9 8660-2829",
                Data_Registro = DateTime.Now
            };
            contexto.Candidatos.Add(candidatoInserir4);
            contexto.SaveChanges();
            //Ação
            var candidatos = contexto.Candidatos;
            var retorno = (from a in candidatos where a.Nome.Equals(candidatoInserir.Nome) select a).FirstOrDefault();

            //Assertiva
            Assert.IsInstanceOfType(candidatos, typeof(IQueryable<Candidato>));
            Assert.AreEqual(retorno, candidatoInserir);
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirCandidatoComMesmoEmailTest()
        {
            var candidatoInserir = new Candidato
            {

                Cpf = "158.639.954-32",
                Email = "marcusfcbarbosa@hotmail.com",
                Idade = 30,
                Nome = "Marcus Fernando Correa Barbosa",
                Status = true,
                Telefone = "(11) 9 8660-2829",
                Data_Registro = DateTime.Now
            };
            candidatoRepositorio.Inserir(candidatoInserir);
        }

    }
}
