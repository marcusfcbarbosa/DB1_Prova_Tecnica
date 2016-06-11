using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Concrete
{
    public class EFTecnologiaRepositorio : ITecnologia
    {
        #region "Construtor"

        DB1Context db1Context;
        public EFTecnologiaRepositorio(DB1Context context)
        {
            db1Context = context;
        }
        #endregion

        #region "implementações"
        public IQueryable<Tecnologia> Tecnologias
        {
            get { return db1Context.Tecnologias.AsQueryable(); }
        }
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="tecnologia"></param>
        public void Inserir(Tecnologia tecnologia)
        {
            if (db1Context.Tecnologias.Where(x => x.Descricao == tecnologia.Descricao) != null)
            {
                throw new InvalidOperationException("Tecnologia ja cadastrada");
            }
            else {
                db1Context.Tecnologias.Add(tecnologia);
                db1Context.SaveChanges();
            }
        }
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            db1Context.Tecnologias.Remove(db1Context.Tecnologias.Where(x => x.Tecnologia_ID == id).FirstOrDefault());
            db1Context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tecnologia"></param>
        public void Alterar(Tecnologia tecnologia)
        {
            var obj = db1Context.Tecnologias.Where(x => x.Tecnologia_ID == tecnologia.Tecnologia_ID).FirstOrDefault();
            if(obj!= null){
               obj.Descricao = tecnologia.Descricao;
               obj.Status = tecnologia.Status;
               db1Context.SaveChanges();
            }
        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Tecnologia> RetornaTodos()
        {
            return db1Context.Tecnologias.ToList();
        }
        #endregion


        /// <summary>
        /// Retorna por descricao
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        public Tecnologia retornaPorDescricao(string descricao)
        {
            var ret = db1Context.Tecnologias.Where(x => x.Descricao == descricao).FirstOrDefault();
            return ret;
        }

        /// <summary>
        /// Retorna todas as tecnologias pelo ID da empresa
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        public List<Tecnologia> RetornaTodasTecnologiasDaEmpresa(int IdEmpresa)
        {
            var ret = (from tec in db1Context.Tecnologias
                       join rel_tec_emp in db1Context.Rel_Empresa_Tecnologias on tec.Tecnologia_ID equals rel_tec_emp.Tecnologia_ID
                       where rel_tec_emp.Empresa_ID == IdEmpresa
                       select tec
                           ).ToList();
            return ret;
        }
    }
}
