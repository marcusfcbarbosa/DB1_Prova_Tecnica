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
    public class EmpresaRepositorioTeste
    {
        /// <summary>
        /// Repositorio
        /// </summary>
        private IEmpresa repositorioEmpresa;
        /// <summary>
        /// contexto
        /// </summary>
        DB1Context contexto = new DB1Context();

        [TestInitialize]
        public void InicializaTeste()
        {
            repositorioEmpresa = new EFEmpresaRepositorio(contexto);
        }
        [TestMethod]
        public void LimparEmpresas()
        {
            var empresas = from e in contexto.Empresas select e;
            if (empresas.Count() > 0)
            {
                foreach (var empresa in empresas)
                {
                    contexto.Empresas.Remove(empresa);
                }
                contexto.SaveChanges();
            }
        }
        [TestMethod]
        public void CargaInicialEmpresaseTrativaParaConsultasLINQ() {

            var empresaInserir = new Empresa
            {
                Cnpj = "02.766.635/0001-20",
                Data_Registro = DateTime.Now,
                Email="sebrae@sebrae.com.br",
                Nome="SEBRAE",
                Status = true,
                Telefone = "99910057",
                Vagas = 10
            };
            contexto.Empresas.Add(empresaInserir);
            
            var empresaInserir2 = new Empresa
            {
                Cnpj = "68.878.583/0001-91",
                Data_Registro = DateTime.Now,
                Email = "eicon@eicon.com.br",
                Nome = "EICON",
                Status = true,
                Telefone = "1212323123",
                Vagas = 12
            };
            contexto.Empresas.Add(empresaInserir2);

            var empresaInserir3 = new Empresa
            {
                Cnpj = "24.472.605/0001-43",
                Data_Registro = DateTime.Now,
                Email = "ecomenergia@ecomenergia.com.br",
                Nome = "ECON ENERGIA",
                Status = true,
                Telefone = "1212323123",
                Vagas = 20
            };
            contexto.Empresas.Add(empresaInserir3);

            var empresaInserir4 = new Empresa
            {
                Cnpj = "67.742.686/0001-67",
                Data_Registro = DateTime.Now,
                Email = "clmtecnologia@clm.com.br",
                Nome = "CLM TECNLOGIA",
                Status = true,
                Telefone = "1212323123",
                Vagas = 2
            };
            contexto.Empresas.Add(empresaInserir4);

            var empresaInserir5 = new Empresa
            {
                Cnpj = "11.560.218/0001-17",
                Data_Registro = DateTime.Now,
                Email = "leanInstitute@lean.com.br",
                Nome = "LEAN INSTITUTE",
                Status = true,
                Telefone = "232334234",
                Vagas = 23
            };
            contexto.Empresas.Add(empresaInserir5);

            var empresaInserir6 = new Empresa
            {
                Cnpj = "46.335.542/0001-16",
                Data_Registro = DateTime.Now,
                Email = "inatel@inatel.br",
                Nome = "INSTITUTO NACIONAL DE TELECOMUNICAÇÕES",
                Status = true,
                Telefone = "234342342332",
                Vagas = 10
            };
            contexto.Empresas.Add(empresaInserir6);


            var empresaInserir7 = new Empresa
            {
                Cnpj = "02.715.545/0001-00",
                Data_Registro = DateTime.Now,
                Email = "tamara.coneglian@db1.com.br",
                Nome = "DBA1 GLOBAL SOFTWARE  (SE EU CONSEGUIR PASSAR NO PROCESSO SELETIVO HEHEHE!!)",
                Status = true,
                Telefone = " (11) 4063-5970",
                Vagas = 1
            };
            contexto.Empresas.Add(empresaInserir7);
            contexto.SaveChanges();
            //Ação
            var empresas = contexto.Empresas;
            var retorno = (from e in empresas where e.Nome.Equals(empresaInserir6.Nome) select e).FirstOrDefault();
            //Assertiva
            Assert.IsInstanceOfType(empresas, typeof(IQueryable<Empresa>));
            Assert.AreEqual(retorno, empresaInserir6);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirEmpresaComMesmoCNPJTeste()
        {
            var empresaInserir = new Empresa
            {
                Cnpj = "02.766.635/0001-20",
                Data_Registro = DateTime.Now,
                Email = "sebrae@sebrae.com.br",
                Nome = "SEBRAE",
                Status = true,
                Telefone = "99910057",
                Vagas = 10
            };
            repositorioEmpresa.Inserir(empresaInserir);
        }


    }
}
