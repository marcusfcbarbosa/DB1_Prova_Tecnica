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
    public class TeconologiaRepositorioTeste
    {
        #region "repositorio"
        private ITecnologia repositorioTecnologia;
        #endregion

        #region "Contexto"
        /// <summary>
        /// contexto
        /// </summary>
        DB1Context contexto = new DB1Context();
        #endregion

        #region "Incializa Ambiente Para testes"
        [TestInitialize]
        public void InicializaTeste()
        {
            repositorioTecnologia = new EFTecnologiaRepositorio(contexto);
        }
             
        [TestMethod]
        public void LimparTecnologias()
        {
            var tecnologias = from t in contexto.Tecnologias select t;
            if (tecnologias.Count() > 0)
            {
                foreach (var tecnologia in tecnologias)
                {
                    contexto.Tecnologias.Remove(tecnologia);
                }
                contexto.SaveChanges();
            }
        }
        #endregion


        #region "Testes"
        [TestMethod]
        public void CargaInicialTecnologiaseTrativaParaConsultasLINQ()
        {
            var tecnologiaInserir = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Plataforma ASP.Net",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir);

            var tecnologiaInserir2 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "WCF",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir2);

            var tecnologiaInserir3 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "WCF RIA",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir3);

            var tecnologiaInserir4 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "C# Orientado a Objeto",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir4);

            var tecnologiaInserir5 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "SQL Server",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir5);

            var tecnologiaInserir6 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "PROCEDURES, VIEWS , TRIGGERS, JOBS, FUNCTIONS, DDL, DML",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir6);

            var tecnologiaInserir7 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "ORM (Object Relational Mapping)",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir7);

            var tecnologiaInserir8 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Webapi ",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir8);

            var tecnologiaInserir9 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Single-Page Applications",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir9);

            var tecnologiaInserir10 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Restfull",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir10);

            var tecnologiaInserir11 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Angular.js",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir11);

            
            var tecnologiaInserir12 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = " Asp .Net Web Forms",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir12);

            var tecnologiaInserir13 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = " - Asp .net MVC 3 / 4 / 5 ",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir13);

            var tecnologiaInserir14 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "MVVM",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir14);

            var tecnologiaInserir15 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "- Entity Framework CodeFirst / DatabaseFirst",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir15);

            var tecnologiaInserir16 = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "TDD DDD BDD",
                Status = true
            };
            contexto.Tecnologias.Add(tecnologiaInserir16);
            contexto.SaveChanges();
            //Ação
            var tecnologias = contexto.Tecnologias;
            var retorno = (from e in tecnologias where e.Descricao.Equals(tecnologiaInserir16.Descricao) select e).FirstOrDefault();
            //Assertiva
            Assert.IsInstanceOfType(tecnologias, typeof(IQueryable<Tecnologia>));
            Assert.AreEqual(retorno, tecnologiaInserir16);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirTecnologiaComMesmaDescricaoTeste()
        {
            var tecnologiaInserir = new Tecnologia
            {
                Data_Registro = DateTime.Now,
                Descricao = "Plataforma ASP.Net",
                Status = true
            };
            repositorioTecnologia.Inserir(tecnologiaInserir);
        }
        #endregion
    }
}