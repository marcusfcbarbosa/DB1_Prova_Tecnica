using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Abstract
{
    public interface ITecnologia
    {
        /// <summary>
        /// Para consultas LINQ
        /// </summary>
        IQueryable<Tecnologia> Tecnologias { get; }

        /// <summary>
        /// Inserir Tecnologia
        /// </summary>
        /// <param name="empresa"></param>
        void Inserir(Tecnologia tecnologia);

        /// <summary>
        //excluir tecnologia
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);

        /// <summary>
        /// Alterar tecnologia
        /// </summary>
        /// <param name="candidato"></param>
        void Alterar(Tecnologia tecnologia);

        /// <summary>
        /// Retorna todas Tecnologias
        /// </summary>
        /// <returns></returns>
        IList<Tecnologia> RetornaTodos();

        /// <summary>
        /// Retorna Tecnologiacom base em sua descricao
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        Tecnologia retornaPorDescricao(String descricao);

        /// <summary>
        /// Retorna todas as tecnologias que a empresa usa
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        List<Tecnologia> RetornaTodasTecnologiasDaEmpresa(Int32 IdEmpresa);

    }
}
