using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Concrete
{
    public class EFEmpresaRepositorio : IEmpresa
    {
        DB1Context db1Context;

        #region "Construtor"
        public EFEmpresaRepositorio(DB1Context context)
        {
            db1Context = context;
        }
        #endregion

        #region "Implementações"
        public IQueryable<Empresa> Empresas
        {
            get { return db1Context.Empresas.AsQueryable(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        public void Inserir(Empresa empresa)
        {
            if (db1Context.Empresas.Where(x => x.Cnpj == empresa.Cnpj || x.Email == empresa.Email) != null)
            {

                throw new InvalidOperationException("Empresa ja cadastrada");
            }
            else
            {
                db1Context.Empresas.Add(empresa);
                db1Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            db1Context.Empresas.Remove(db1Context.Empresas.Where(x => x.Empresa_ID == id).FirstOrDefault());
            db1Context.SaveChanges();
        }
        /// <summary>
        /// Alterar Empresa
        /// </summary>
        /// <param name="empresa"></param>
        public void Alterar(Empresa empresa)
        {
            var obj = db1Context.Empresas.Where(x => x.Empresa_ID == empresa.Empresa_ID).FirstOrDefault();
            if (obj != null) {
                obj.Nome = empresa.Nome;
                obj.Cnpj = empresa.Cnpj;
                obj.Email = empresa.Email;
                obj.Telefone = empresa.Telefone;
                obj.Vagas = empresa.Vagas;
                obj.Status = empresa.Status;
                db1Context.SaveChanges();
            }
        }

        /// <summary>
        /// Retornar todos
        /// </summary>
        /// <returns></returns>
        public IList<Empresa> RetornaTodos()
        {
            return db1Context.Empresas.ToList();
        }

        /// <summary>
        /// Busca com base no CNPJ
        /// </summary>
        /// <param name="Cnpj"></param>
        /// <returns></returns>
        public Empresa BuscaPorCNPJ(string Cnpj)
        {
            return db1Context.Empresas.Where(x => x.Cnpj == Cnpj).FirstOrDefault();
        }

        /// <summary>
        /// Relatorio Final da prova de avaliação técnica
        /// </summary>
        /// <returns></returns>
        public Relatorio Relatorio()
        {
            var empresa = db1Context.Empresas.Where(x => x.Cnpj == "02.715.545/0001-00").FirstOrDefault();
            var tecnologias = (from tec in db1Context.Tecnologias
                               join r_e_t in db1Context.Rel_Empresa_Tecnologias on tec.Tecnologia_ID equals r_e_t.Tecnologia_ID
                               join emp in db1Context.Empresas on r_e_t.Empresa_ID equals emp.Empresa_ID
                               where emp.Empresa_ID == empresa.Empresa_ID
                               select tec).ToList();
            var candidato = (from cand in db1Context.Candidatos
                             join r_c_t in db1Context.Rel_Candidato_Tecnologias on cand.Candidato_ID equals r_c_t.Candidato_ID
                             join r_e_t in db1Context.Rel_Empresa_Tecnologias on r_c_t.Tecnologia_ID equals r_e_t.Tecnologia_ID
                             where r_e_t.Empresa_ID == empresa.Empresa_ID
                             select cand).FirstOrDefault();
            Relatorio rel = new Relatorio();
            rel.NomeEmpresa = empresa.Nome;
            rel.NomeCandidato = candidato.Nome;
            foreach (var tecnologia in tecnologias)
                rel.Tecnologias.Add(tecnologia.Descricao);
            return rel;
        }
        #endregion
    }
}
