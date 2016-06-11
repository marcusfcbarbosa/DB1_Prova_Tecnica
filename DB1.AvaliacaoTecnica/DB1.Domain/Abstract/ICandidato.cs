using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Abstract
{
    public interface ICandidato
    {
        /// <summary>
        /// Para consultas LINQ
        /// </summary>
        IQueryable<Candidato> Candidatos { get; }

        /// <summary>
        /// Inserir candidato
        /// </summary>
        /// <param name="candidato"></param>
        void Inserir(Candidato candidato);

        /// <summary>
        //excluir candidato
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);

        /// <summary>
        /// Alterar candidato
        /// </summary>
        /// <param name="candidato"></param>
        void Alterar(Candidato candidato);

        /// <summary>
        /// Retorna todos candidatos
        /// </summary>
        /// <returns></returns>
        IList<Candidato> RetornaTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Candidato RetornaPorCPF(string cpf);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        List<Tecnologia> RetornaTodasTecnologiasDoCandidato(Int32 IdCandidato);
    }
}
