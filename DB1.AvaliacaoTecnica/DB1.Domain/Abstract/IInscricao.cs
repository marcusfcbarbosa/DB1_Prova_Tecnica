using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Abstract
{
    public interface IInscricao
    {
        /// <summary>
        /// Inserir Rel_Candidato_Tecnologia
        /// </summary>
        /// <param name="empresa"></param>
        void Inserir(Int32 Candidato_ID, Int32 Empresa_ID, Int32 Tecnologia_ID);

        /// <summary>
        //excluir Rel_Candidato_Tecnologia
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);

        

    }
}
