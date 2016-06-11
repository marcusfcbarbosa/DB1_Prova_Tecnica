using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Concrete
{
    public class EFCandidatoRepositorio : ICandidato
    {
        DB1Context db1Context;
        public EFCandidatoRepositorio(DB1Context context)
        {
            db1Context = context;
        }

        public IQueryable<Candidato> Candidatos
        {
            get { return db1Context.Candidatos.AsQueryable(); }
        }

        public void Inserir(Candidato candidato)
        {
            if (db1Context.Candidatos.Where(x => x.Cpf == candidato.Cpf || x.Email == candidato.Email) != null)
            {
                throw new InvalidOperationException("Candidato ja se encontra cadastrado");
            }
            else {
                db1Context.Candidatos.Add(candidato);
                db1Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            db1Context.Candidatos.Remove(db1Context.Candidatos.Where(x => x.Candidato_ID == id).FirstOrDefault());
            db1Context.SaveChanges();
        }

        public void Alterar(Candidato candidato)
        {
            var obj = db1Context.Candidatos.Where(x => x.Candidato_ID == candidato.Candidato_ID).FirstOrDefault();
            if (obj != null)
            {
                obj.Cpf = candidato.Cpf;
                obj.Email = candidato.Email;
                obj.Idade = candidato.Idade;
                obj.Nome = candidato.Nome;
                obj.Status = candidato.Status;
                obj.Telefone = candidato.Telefone;
                db1Context.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna todos os candidatos
        /// </summary>
        /// <returns></returns>
        public IList<Candidato> RetornaTodos()
        {
            return db1Context.Candidatos.ToList();
        }
        /// <summary>
        /// Retorna Candidato com busca no CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Candidato RetornaPorCPF(string cpf)
        {
            return db1Context.Candidatos.Where(x => x.Cpf == cpf).FirstOrDefault();
        }

        /// <summary>
        ///Retorna Todas Tecnologias Do Candidato
        /// </summary>
        /// <param name="IdCandidato"></param>
        /// <returns></returns>
        public List<Tecnologia> RetornaTodasTecnologiasDoCandidato(int IdCandidato)
        {
            var ret = (from tec in db1Context.Tecnologias
                       join rel_tec_emp in db1Context.Rel_Candidato_Tecnologias on tec.Tecnologia_ID equals rel_tec_emp.Tecnologia_ID
                       where rel_tec_emp.Candidato_ID == IdCandidato
                       select tec
                           ).ToList();
            return ret;
        }
    
    }
}
