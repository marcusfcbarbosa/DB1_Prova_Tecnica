using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Abstract
{
    public interface IEmpresa
    {

        /// <summary>
        /// Para consultas LINQ
        /// </summary>
        IQueryable<Empresa> Empresas { get; }

        /// <summary>
        /// Inserir empresa
        /// </summary>
        /// <param name="empresa"></param>
        void Inserir(Empresa empresa);

        /// <summary>
        /// Retorna a empresa com base no CNPJ
        /// </summary>
        /// <param name="Cnpj"></param>
        /// <returns></returns>
        Empresa BuscaPorCNPJ(string Cnpj);

        /// <summary>
        //excluir empresa
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);

        /// <summary>
        /// Alterar empresa
        /// </summary>
        /// <param name="candidato"></param>
        void Alterar(Empresa empresa);

        /// <summary>
        /// Retorna todas empresas
        /// </summary>
        /// <returns></returns>
        IList<Empresa> RetornaTodos();

        /// <summary>
        /// Relatorio Final
        /// </summary>
        /// <returns></returns>
        Relatorio Relatorio();
    }
}
