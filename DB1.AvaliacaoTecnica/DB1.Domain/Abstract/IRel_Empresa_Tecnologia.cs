using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Abstract
{
    public interface IRel_Empresa_Tecnologia
    {

        /// <summary>
        /// Inseri Rel_Empresa_Tecnologia
        /// </summary>
        /// <param name="rel_Empresa_Tecnologia"></param>
        void Inserir(Int32 Tecnologia_ID, Int32 Empresa_ID);

        /// <summary>
        //excluir Rel_Empresa_Tecnologia
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);


    }
}
